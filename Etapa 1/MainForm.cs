using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Final_Project
{
    public partial class FormFinalProject : Form
    {
        // CONSTANTS
        private enum SideLists { FirstSide = 1, SecondSide }
        private enum SurroundingPixelMovement { UpperSide, RightSide, LowerSide, LeftSide }
        private enum MSTAlgorithms { Kruskal, Prim }
        private enum Tabs { Graph, Points, Random, Trees, Preys, Breadth }
        const int KruskalMSTPenWidth = 12;
        const int PrimMSTPenWidth = 4;

        // VARIABLES
        private Graph circleGraph;
        private List<Circle> circleList;
        private List<CirclePair> circlePairList;
        private Graph kruskalMST;
        private Graph primMST;
        private List<Agent> MSTAgents;
        private List<Prey> globalPreys;
        private List<Predator> globalPredators;
        private Graph dijkstraGraph;
        private Bitmap processingImage;
        private Bitmap preysAndPredatorsImage;
        private Bitmap closestPairOfPointsImage;
        private Bitmap MSTImage;
        private Bitmap MSTAgentsImage;
        private Bitmap BFSTreeImage;
        private Bitmap agentsWithRandomPathImage;
        private Graphics imageGraphics;
        private Random numberGenerator;
        private Stopwatch bruteForceOnImageStopwatch;
        private Stopwatch bruteForceOnGraphStopwatch;
        private Stopwatch divideAndConquerOnImageStopwatch;
        private List<Point[]> treeByBreadthPoints;
        private List<Agent> agentsWithRandomPath;

        // FORM METHODS
        public FormFinalProject()
        {
            InitializeComponent();

            OpenFileDialogLoadImage.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            circleList = new List<Circle>();
            circlePairList = new List<CirclePair>();
            globalPredators = new List<Predator>();
            treeByBreadthPoints = new List<Point[]>();
            numberGenerator = new Random();
            agentsWithRandomPath = new List<Agent>();
            MSTAgents = new List<Agent>();
            globalPreys = new List<Prey>();

            // Graph Creation Button
            ButtonBuildGraph.Enabled = false;

            // Points Tab
            ButtonFindClosestPairOfPoints.Enabled = false;

            // Random Tab
            NumericUpDownAgentsWithRandomPath.Enabled = false;
            ButtonCreateAgentsWithRandomPath.Enabled = false;

            // Trees Tab
            ButtonGenerateMST.Enabled = false;
            NumericUpDownMSTAgents.Enabled = false;
            RadioButtonKruskal.Checked = true;
            RadioButtonKruskal.Enabled = false;
            RadioButtonPrim.Enabled = false;
            CheckBoxRandomOrigins.Enabled = false;
            ButtonCreateMSTAgents.Enabled = false;

            // Preys Tab
            NumericUpDownPreys.Enabled = false;
            ButtonAddPreys.Enabled = false;
            NumericUpDownPredators.Enabled = false;
            ButtonAddPredators.Enabled = false;
            ButtonStart.Enabled = false;

            // Breadth Tab
            ButtonGenerateTreeByBreadth.Enabled = false;
        }

        private void ButtonLoadImage_Click(object sender, EventArgs e)
        {
            if (OpenFileDialogLoadImage.ShowDialog() == DialogResult.OK)
            {
                ResetToolsAndAbstractDataTypes();

                processingImage = new Bitmap(OpenFileDialogLoadImage.FileName);
                preysAndPredatorsImage = new Bitmap(processingImage.Width, processingImage.Height);
                closestPairOfPointsImage = new Bitmap(processingImage.Width, processingImage.Height);
                MSTImage = new Bitmap(processingImage);
                BFSTreeImage = new Bitmap(processingImage.Width, processingImage.Height);
                agentsWithRandomPathImage = new Bitmap(processingImage.Width, processingImage.Height);
                MSTAgentsImage = new Bitmap(processingImage.Width, processingImage.Height);

                PictureBoxImage.BackgroundImage = processingImage;
                /**PictureBoxImage.Image = animationImage;**/

                // Graph Creation Button
                ButtonBuildGraph.Enabled = true;
            }
        }

        private void ButtonBuildGraph_Click(object sender, EventArgs e)
        {
            ProcessBitmap();
            SetValidCirclePairs();

            circleGraph = new Graph(circleList, circlePairList);
            UpdateGraphDetails();

            imageGraphics = Graphics.FromImage(processingImage);
            DrawCircleConnections();
            DrawCircleCentres();

            // Graph Creation Button
            ButtonBuildGraph.Enabled = false;

            // Points Tab
            ButtonFindClosestPairOfPoints.Enabled = true;

            // Random Tab
            NumericUpDownAgentsWithRandomPath.Maximum = circleList.Count;
            NumericUpDownAgentsWithRandomPath.Enabled = true;
            ButtonCreateAgentsWithRandomPath.Enabled = true;

            // Trees Tab
            MSTImage = new Bitmap(processingImage);
            ButtonGenerateMST.Enabled = true;
            /**NumericUpDownMSTAgents.Maximum = circleList.Count;**/

            ButtonAddPreys.Enabled = true;
            ButtonGenerateTreeByBreadth.Enabled = true;
            NumericUpDownPreys.Maximum = circleList.Count;
            NumericUpDownPreys.Enabled = true;
        }

        private void TabControlCapabilities_Click(object sender, EventArgs e)
        {
            if (TimerAgentsWithRandomPathMovement.Enabled)
            {
                TimerAgentsWithRandomPathMovement.Enabled = false;

                TabControlCapabilities.SelectedIndex = (int)Tabs.Random;
                ShowErrorMessageBox("Hay una simulación en curso.");

                TimerAgentsWithRandomPathMovement.Enabled = true;
            }
            else if (TimerMSTAgentsMovement.Enabled)
            {
                TimerMSTAgentsMovement.Enabled = false;

                TabControlCapabilities.SelectedIndex = (int)Tabs.Trees;
                ShowErrorMessageBox("Hay una simulación en curso.");

                TimerMSTAgentsMovement.Enabled = true;
            }
            else if (TimerPreysAndPredatorsMovement.Enabled)
            {
                TimerPreysAndPredatorsMovement.Enabled = false;

                TabControlCapabilities.SelectedIndex = (int)Tabs.Preys;
                ShowErrorMessageBox("Hay una simulación en curso.");

                TimerPreysAndPredatorsMovement.Enabled = true;
            }

            switch (TabControlCapabilities.SelectedIndex)
            {
                case (int)Tabs.Graph:
                    PictureBoxImage.BackgroundImage = processingImage;
                    PictureBoxImage.Image = null;
                    break;

                case (int)Tabs.Points:
                    PictureBoxImage.BackgroundImage = processingImage;
                    PictureBoxImage.Image = closestPairOfPointsImage;
                    break;

                case (int)Tabs.Random:
                    PictureBoxImage.BackgroundImage = processingImage;
                    PictureBoxImage.Image = agentsWithRandomPathImage;
                    break;

                case (int)Tabs.Trees:
                    PictureBoxImage.BackgroundImage = MSTImage;
                    PictureBoxImage.Image = MSTAgentsImage;
                    break;

                case (int)Tabs.Preys:
                    PictureBoxImage.BackgroundImage = processingImage;
                    PictureBoxImage.Image = preysAndPredatorsImage;
                    break;

                case (int)Tabs.Breadth:
                    PictureBoxImage.BackgroundImage = processingImage;
                    PictureBoxImage.Image = BFSTreeImage;
                    break;
            }
        }

        private void ButtonFindClosestPairOfPoints_Click(object sender, EventArgs e)
        {
            if (circleList.Count <= 1)
            {
                ShowErrorMessageBox("No se encontró más de un punto.");

                return;
            }

            /**PictureBoxImage.Image = closestPairOfPointsImage;**/
            imageGraphics = Graphics.FromImage(closestPairOfPointsImage);

            FindClosestPairOfPointsByBruteForceOnImage();
            LabelBruteForceOnImageExecutionTimeValue.Text = bruteForceOnImageStopwatch.ElapsedMilliseconds.ToString() + " ms";

            FindClosestPairOfPointsByBruteForceOnGraph();
            LabelBruteForceOnGraphExecutionTimeValue.Text = bruteForceOnGraphStopwatch.ElapsedMilliseconds.ToString() + " ms";

            FindClosestPairOfPointsByDivideAndConquerOnImage();
            LabelDivideAndConquerOnImageExecutionTimeValue.Text = divideAndConquerOnImageStopwatch.ElapsedMilliseconds.ToString() + " ms";

            ButtonFindClosestPairOfPoints.Enabled = false;
        }

        private void ButtonGenerateMST_Click(object sender, EventArgs e)
        {
            if (!circleGraph.HasEdges())
            {
                ShowErrorMessageBox("El grafo no tiene aristas.");

                return;
            }

            int selectedOriginVertexIndex = 0;

            using (FormVertexSelection PrimMSTOriginVertexForm = new FormVertexSelection(circleGraph.VertexList, "Origen"))
            {
                if (PrimMSTOriginVertexForm.ShowDialog() == DialogResult.OK)
                {
                    selectedOriginVertexIndex = PrimMSTOriginVertexForm.GetSelectedVertex();
                }
                else
                {
                    return;
                }
            }

            imageGraphics = Graphics.FromImage(MSTAgentsImage);
            imageGraphics.Clear(Color.Transparent);

            TreeViewMSTAgentDetails.Nodes.Clear();

            MSTImage = new Bitmap(processingImage);
            PictureBoxImage.BackgroundImage = MSTImage;

            imageGraphics = Graphics.FromImage(MSTImage);

            DrawMSTWithKruskal();
            DrawMSTWithPrim(circleGraph.VertexList[selectedOriginVertexIndex]);

            /**PictureBoxImage.Refresh();**/

            // Trees Tab
            NumericUpDownMSTAgents.Maximum = circleList.Count;
            NumericUpDownMSTAgents.Enabled = true;
            RadioButtonKruskal.Enabled = true;
            RadioButtonPrim.Enabled = true;
            CheckBoxRandomOrigins.Enabled = true;
            ButtonCreateMSTAgents.Enabled = true;

            /**ButtonGenerateMST.Enabled = false;
            NumericUpDownMSTAgents.Maximum = circleList.Count;
            NumericUpDownMSTAgents.Enabled = true;
            ButtonCreateMSTAgents.Enabled = true;
            ButtonAddPreys.Enabled = false;
            NumericUpDownAgentsWithRandomPath.Enabled = false;
            ButtonCreateAgentsWithRandomPath.Enabled = false;
            ButtonFindClosestPairOfPoints.Enabled = false;
            ButtonGenerateTreeByBreadth.Enabled = false;**/
        }

        private void ButtonCreateMSTAgents_Click(object sender, EventArgs e)
        {
            if (NumericUpDownMSTAgents.Value == 0)
            {
                ShowErrorMessageBox("El número de agentes debe ser mayor a cero.");

                return;
            }

            List<Vertex> remainingKruskalMSTVertexes = new List<Vertex>(kruskalMST.VertexList);
            List<Vertex> remainingPrimMSTVertexes = new List<Vertex>(primMST.VertexList);
            Vertex originVertex;
            int numberOfMSTAgents = (int)NumericUpDownMSTAgents.Value;

            imageGraphics = Graphics.FromImage(MSTAgentsImage);

            MSTAgents.Clear();
            TreeViewMSTAgentDetails.Nodes.Clear();

            if (CheckBoxRandomOrigins.Checked)
            {
                for (int i = 0; i < numberOfMSTAgents; i++)
                {
                    if (RadioButtonKruskal.Checked)
                    {
                        originVertex = remainingKruskalMSTVertexes[numberGenerator.Next(0, remainingKruskalMSTVertexes.Count)];

                        MSTAgents.Add(new Agent(i + 1, kruskalMST.VertexList.Find(Vertex => Vertex == originVertex)));

                        remainingKruskalMSTVertexes.Remove(originVertex);
                    }
                    else
                    {
                        originVertex = remainingPrimMSTVertexes[numberGenerator.Next(0, remainingPrimMSTVertexes.Count)];

                        MSTAgents.Add(new Agent(i + 1, primMST.VertexList.Find(Vertex => Vertex == originVertex)));

                        remainingPrimMSTVertexes.Remove(originVertex);
                    }

                    MSTAgents[MSTAgents.Count - 1].GenerateMSTPath();
                }
            }
            else
            {
                remainingKruskalMSTVertexes.Sort((vertexOne, vertexTwo) => vertexOne.VertexCircle.ID.CompareTo(vertexTwo.VertexCircle.ID));
                remainingPrimMSTVertexes.Sort((vertexOne, vertexTwo) => vertexOne.VertexCircle.ID.CompareTo(vertexTwo.VertexCircle.ID));

                for (int i = 0; i < numberOfMSTAgents; i++)
                {
                    if (RadioButtonKruskal.Checked)
                    {
                        using (FormVertexSelection agentOriginVertexForm = new FormVertexSelection(remainingKruskalMSTVertexes, "Origen con Kruskal"))
                        {
                            if (agentOriginVertexForm.ShowDialog() == DialogResult.OK)
                            {
                                originVertex = remainingKruskalMSTVertexes[agentOriginVertexForm.GetSelectedVertex()];

                                MSTAgents.Add(new Agent(i + 1, kruskalMST.VertexList.Find(Vertex => Vertex == originVertex)));

                                remainingKruskalMSTVertexes.Remove(originVertex);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        using (FormVertexSelection agentOriginVertexForm = new FormVertexSelection(remainingPrimMSTVertexes, "Origen con Prim"))
                        {
                            if (agentOriginVertexForm.ShowDialog() == DialogResult.OK)
                            {
                                originVertex = remainingPrimMSTVertexes[agentOriginVertexForm.GetSelectedVertex()];

                                MSTAgents.Add(new Agent(i + 1, primMST.VertexList.Find(Vertex => Vertex == originVertex)));

                                remainingPrimMSTVertexes.Remove(originVertex);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                    MSTAgents[MSTAgents.Count - 1].GenerateMSTPath();
                }
            }

            /**PictureBoxImage.BackgroundImage = MSTImage;**/
            /**PictureBoxImage.Image = animationImage;**/

            imageGraphics = Graphics.FromImage(MSTAgentsImage);

            // Trees Tab
            ButtonGenerateMST.Enabled = false;
            NumericUpDownMSTAgents.Enabled = false;
            RadioButtonKruskal.Enabled = false;
            RadioButtonPrim.Enabled = false;
            CheckBoxRandomOrigins.Enabled = false;
            ButtonCreateMSTAgents.Enabled = false;

            TimerMSTAgentsMovement.Enabled = true;
        }

        private void TimerMSTAgentsMovement_Tick(object sender, EventArgs e)
        {
            int numberOfAgentsHalted = 0;

            imageGraphics.Clear(Color.Transparent);

            foreach (Agent currentAgent in MSTAgents)
            {
                DrawAgent(currentAgent.ID.ToString(), currentAgent.Path[currentAgent.LinePosition], Color.Firebrick);

                if (currentAgent.LinePosition == currentAgent.Path.Count - 1)
                {
                    numberOfAgentsHalted++;

                    if (numberOfAgentsHalted == MSTAgents.Count)
                    {
                        TimerMSTAgentsMovement.Enabled = false;

                        // Tree Tab
                        ButtonGenerateMST.Enabled = true;
                        NumericUpDownMSTAgents.Enabled = true;
                        RadioButtonKruskal.Enabled = true;
                        RadioButtonPrim.Enabled = true;
                        CheckBoxRandomOrigins.Enabled = true;
                        ButtonCreateMSTAgents.Enabled = true;

                        /**PictureBoxImage.BackgroundImage = processingImage;**/

                        UpdateMSTAgentsDetails();
                    }
                }

                currentAgent.UpdateLinePosition();
            }

            PictureBoxImage.Refresh();
        }

        private void ButtonAddPrey_Click(object sender, EventArgs e)
        {
            if (!circleGraph.HasEdges())
            {
                ShowErrorMessageBox("El grafo no tiene aristas.");

                return;
            }
            else if (NumericUpDownPreys.Value == 0)
            {
                ShowErrorMessageBox("El número de presas debe ser mayor a cero.");

                return;
            }

            List<Vertex> remainingVertexes;
            Prey newPrey;
            bool validPrey;
            int numberOfPreys = (int)NumericUpDownPreys.Value;

            dijkstraGraph = new Graph(circleList, circlePairList);
            remainingVertexes = new List<Vertex>(dijkstraGraph.VertexList);

            /**PictureBoxImage.Image = animationImage;**/

            imageGraphics = Graphics.FromImage(preysAndPredatorsImage);
            imageGraphics.Clear(Color.Transparent);

            globalPreys.Clear();

            for (int i = 0; i < numberOfPreys; i++)
            {
                newPrey = new Prey();
                validPrey = false;
                
                using (FormPreyVertexSelection preyVertexSelectionForm = new FormPreyVertexSelection(remainingVertexes, dijkstraGraph.VertexList, (i + 1).ToString()))
                {
                    while (!validPrey)
                    {
                        if (preyVertexSelectionForm.ShowDialog() == DialogResult.OK)
                        {
                            newPrey.OriginVertex = dijkstraGraph.VertexList.Find(Vertex => Vertex == remainingVertexes[preyVertexSelectionForm.GetSelectedOriginVertex()]);

                            if (newPrey.OriginVertex == dijkstraGraph.VertexList[preyVertexSelectionForm.GetSelectedDestinationVertex()])
                            {
                                ShowErrorMessageBox("El vértice destino no puede ser igual al origen.");
                            }
                            else
                            {
                                try
                                {
                                    newPrey.GeneratePath(dijkstraGraph.VertexList, dijkstraGraph.VertexList[preyVertexSelectionForm.GetSelectedDestinationVertex()]);

                                    newPrey.ID = i + 1;
                                    globalPreys.Add(newPrey);

                                    DrawAgent(newPrey.ID.ToString(), newPrey.OriginVertex.VertexCircle.Centre, Color.SeaGreen);
                                    PictureBoxImage.Refresh();

                                    validPrey = true;
                                    remainingVertexes.RemoveAt(preyVertexSelectionForm.GetSelectedOriginVertex());
                                }
                                catch (NullReferenceException)
                                {
                                    ShowErrorMessageBox("No existe una ruta entre el vértice origen y el destino.");

                                    newPrey.DijkstraElements.Clear();
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }

            // Preys Tab
            NumericUpDownPreys.Enabled = false;
            ButtonAddPreys.Enabled = false;
            NumericUpDownPredators.Maximum = dijkstraGraph.VertexList.Count - numberOfPreys;
            NumericUpDownPredators.Enabled = true;
            ButtonAddPredators.Enabled = true;
        }

        private void ButtonAddPredators_Click(object sender, EventArgs e)
        {
            List<Vertex> availableVertexes = new List<Vertex>();
            Vertex chosenVertex;
            int numberOfPredators = (int)NumericUpDownPredators.Value;
            
            foreach (Vertex currentVertex in dijkstraGraph.VertexList)
            {
                if (globalPreys.Find(Prey => Prey.OriginVertex == currentVertex) == null)
                {
                    availableVertexes.Add(currentVertex);
                }
            }

            imageGraphics = Graphics.FromImage(preysAndPredatorsImage);

            globalPredators.Clear();

            for (int i = 0; i < numberOfPredators; i++)
            {
                chosenVertex = availableVertexes[numberGenerator.Next(0, availableVertexes.Count)];

                globalPredators.Add(new Predator(i + 1, chosenVertex));

                DrawAgent("D", chosenVertex.VertexCircle.Centre, Color.Firebrick);

                availableVertexes.Remove(chosenVertex);
            }

            PictureBoxImage.Refresh();
            
            // Preys Tab
            NumericUpDownPredators.Enabled = false;
            ButtonAddPredators.Enabled = false;
            ButtonStart.Enabled = true;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            foreach (Prey currentPrey in globalPreys)
            {
                currentPrey.IsActive = true;
            }

            foreach (Predator currentPredator in globalPredators)
            {
                currentPredator.GeneratePath();
            }

            imageGraphics = Graphics.FromImage(preysAndPredatorsImage);

            // Preys Tab
            ButtonStart.Enabled = false;

            TimerPreysAndPredatorsMovement.Enabled = true;
        }

        private void TimerPreysAndPredatorsMovement_Tick(object sender, EventArgs e)
        {
            Prey globalPrey;

            imageGraphics.Clear(Color.Transparent);

            for (int i = 0; i < globalPreys.Count; i++)
            {
                globalPrey = globalPreys[i];

                if (!globalPrey.IsActive)
                {
                    bool validDestination = false;

                    TimerPreysAndPredatorsMovement.Enabled = false;

                    globalPreys[i] = new Prey(globalPrey.ID, globalPrey.CurrentEdge.Destination);
                    globalPrey = globalPreys[i];

                    while (!validDestination)
                    {
                        using (FormVertexSelection preyDestinationVertexSelectionForm = new FormVertexSelection(dijkstraGraph.VertexList, "Destino Para Presa " + globalPrey.ID.ToString()))
                        {
                            if (preyDestinationVertexSelectionForm.ShowDialog() == DialogResult.OK)
                            {
                                if (dijkstraGraph.VertexList[preyDestinationVertexSelectionForm.GetSelectedVertex()] == globalPrey.OriginVertex)
                                {
                                    ShowErrorMessageBox("El vértice destino no puede ser igual al origen.");
                                }
                                else
                                {
                                    try
                                    {
                                        globalPrey.GeneratePath(dijkstraGraph.VertexList, dijkstraGraph.VertexList[preyDestinationVertexSelectionForm.GetSelectedVertex()]);

                                        globalPrey.IsActive = true;
                                        TimerPreysAndPredatorsMovement.Enabled = true;
                                        validDestination = true;
                                    }
                                    catch (NullReferenceException)
                                    {
                                        ShowErrorMessageBox("No existe una ruta entre el vértice origen y el destino.");

                                        globalPrey.DijkstraElements.Clear();
                                    }
                                }
                            }
                            else
                            {
                                if (globalPreys.Count == 1)
                                {
                                    DrawAgent(globalPrey.ID.ToString(), globalPrey.OriginVertex.VertexCircle.Centre, Color.SeaGreen);
                                }

                                globalPreys.Remove(globalPrey);
                                i--;

                                validDestination = true;

                                if (globalPreys.Count == 0)
                                {
                                    foreach (Predator globalPredator in globalPredators)
                                    {
                                        DrawAgent("D", globalPredator.CurrentEdge.LinePoints[globalPredator.EdgePosition], Color.Firebrick);
                                    }

                                    // Preys Tab
                                    NumericUpDownPreys.Enabled = true;
                                    ButtonAddPreys.Enabled = true;

                                    PictureBoxImage.Refresh();

                                    return;
                                }
                                else
                                {
                                    TimerPreysAndPredatorsMovement.Enabled = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    globalPrey.UpdateEdgePosition();

                    DrawAgent(globalPrey.ID.ToString(), globalPrey.CurrentEdge.LinePoints[globalPrey.EdgePosition], Color.SeaGreen);
                }
            }

            foreach (Predator globalPredator in globalPredators)
            {
                globalPredator.UpdateEdgePosition();

                // Not sure if this should be here, but let's give it a go
                if (globalPredator.HuntingMode)
                {
                    if (globalPredator.TryHunting())
                    {
                        foreach (Prey huntedPrey in globalPredator.HuntedPreys)
                        {
                            globalPreys.Remove(huntedPrey);
                        }

                        globalPredator.HuntedPreys.Clear();

                        if (globalPreys.Count == 0)
                        {
                            TimerPreysAndPredatorsMovement.Enabled = false;

                            // Preys Tab
                            NumericUpDownPreys.Enabled = true;
                            ButtonAddPreys.Enabled = true;

                            imageGraphics.Clear(Color.Transparent);

                            DrawAgent("D", globalPredator.CurrentEdge.LinePoints[globalPredator.EdgePosition], Color.Firebrick);

                            PictureBoxImage.Refresh();

                            return;
                        }
                    }
                }

                DrawAgent("D", globalPredator.CurrentEdge.LinePoints[globalPredator.EdgePosition], Color.Firebrick);
            }

            PictureBoxImage.Refresh();
        }

        private void ButtonGenerateTreeByBreadth_Click(object sender, EventArgs e)
        {
            if (!circleGraph.HasEdges())
            {
                ShowErrorMessageBox("El grafo no tiene aristas.");

                return;
            }

            foreach (Vertex graphVertex in circleGraph.VertexList)
            {
                treeByBreadthPoints.Clear();

                if (BreadthFirstSearch(graphVertex))
                {
                    PictureBoxImage.Image = BFSTreeImage;

                    imageGraphics = Graphics.FromImage(BFSTreeImage);

                    foreach(Point[] pointPair in treeByBreadthPoints)
                    {
                        DrawLine(pointPair[0], pointPair[1], Color.MidnightBlue, 5);
                    }

                    DrawCircle(graphVertex.VertexCircle.Centre, 15, Color.Aqua);
                    PictureBoxImage.Refresh();

                    // Breadth Tab
                    ButtonGenerateTreeByBreadth.Enabled = false;

                    return;
                }
            }

            ShowErrorMessageBox("No se encontró un arbol.");
        }

        private void ButtonCreateAgentsWithRandomPath_Click(object sender, EventArgs e)
        {
            if (!circleGraph.HasEdges())
            {
                ShowErrorMessageBox("El grafo no cuenta con aristas.");
            }
            else if (NumericUpDownAgentsWithRandomPath.Value == 0)
            {
                ShowErrorMessageBox("El número de agentes debe ser mayor a cero.");
            }
            else
            {
                List<Vertex> remainingVertexList = new List<Vertex>(circleGraph.VertexList);
                Agent newAgent;
                int originVertexIndex;

                agentsWithRandomPath.Clear();
                TreeViewAgentsWithRandomPathDetails.Nodes.Clear();

                for (int i = 0; i < NumericUpDownAgentsWithRandomPath.Value; i++)
                {
                    originVertexIndex = numberGenerator.Next(0, remainingVertexList.Count);

                    newAgent = new Agent(i + 1, circleGraph.VertexList.Find(Vertex => Vertex == remainingVertexList[originVertexIndex]));

                    newAgent.GenerateRandomPath(numberGenerator);

                    agentsWithRandomPath.Add(newAgent);

                    remainingVertexList.RemoveAt(originVertexIndex);
                }

                /**PictureBoxImage.Image = animationImage;**/
                imageGraphics = Graphics.FromImage(agentsWithRandomPathImage);

                // Random Tab
                NumericUpDownAgentsWithRandomPath.Enabled = false;
                ButtonCreateAgentsWithRandomPath.Enabled = false;

                TimerAgentsWithRandomPathMovement.Enabled = true;
            }
        }

        private void TimerAgentsWithRandomPathMovement_Tick(object sender, EventArgs e)
        {
            int numberOfAgentsHalted = 0;

            imageGraphics.Clear(Color.Transparent);

            foreach (Agent currentAgent in agentsWithRandomPath)
            {
                DrawCircle(currentAgent.Path[currentAgent.LinePosition], 30, Color.Firebrick);

                imageGraphics.DrawString(currentAgent.ID.ToString(), new Font("Arial", 20), new SolidBrush(Color.White),
                    currentAgent.Path[currentAgent.LinePosition].X - 11, currentAgent.Path[currentAgent.LinePosition].Y - 15);

                if (currentAgent.LinePosition == currentAgent.Path.Count - 1)
                {
                    numberOfAgentsHalted++;
                }

                currentAgent.UpdateLinePosition();
            }

            PictureBoxImage.Refresh();

            if (numberOfAgentsHalted == agentsWithRandomPath.Count)
            {
                TimerAgentsWithRandomPathMovement.Enabled = false;

                // Random Tab
                NumericUpDownAgentsWithRandomPath.Enabled = true;
                ButtonCreateAgentsWithRandomPath.Enabled = true;

                UpdateAgentsWithRandomPathDetails();
            }
        }

        // USER METHODS
        private void ShowErrorMessageBox(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DrawAgent(string ID, Point location, Color color)
        {
            DrawCircle(location, 30, color);

            imageGraphics.DrawString(ID, new Font("Arial", 20), new SolidBrush(Color.White), location.X - 11, location.Y - 15);
        }

        private void DrawMSTWithKruskal()
        {
            List<Edge> solutionEdges = BuildMSTWithKruskal();

            foreach (Edge currentEdge in solutionEdges)
            {
                DrawLine(currentEdge.Origin.VertexCircle.Centre, currentEdge.Destination.VertexCircle.Centre, Color.MediumVioletRed, KruskalMSTPenWidth);
            }

            LabelKruskalMSTTotalWeightValue.Text = kruskalMST.GetTotalWeight().ToString();

            PictureBoxImage.Refresh();

            using (FormMSTSolutionSet MSTSolutionSetForm = new FormMSTSolutionSet(solutionEdges, "Kruskal"))
            {
                MSTSolutionSetForm.ShowDialog();
            }
        }

        private List<Edge> BuildMSTWithKruskal()
        {
            List<Edge> candidateEdges = circleGraph.GetEdges(), promisingEdges = new List<Edge>();
            List<ConnectedComponent> connectedComponents = new List<ConnectedComponent>();
            List<Vertex> emptyVertexes = new List<Vertex>();
            Edge selectedEdge;
            ConnectedComponent originConnectedComponent, destinationConnectedComponent;

            foreach (Circle currentCircle in circleList)
            {
                connectedComponents.Add(new ConnectedComponent(new Vertex(currentCircle)));
            }

            candidateEdges.Sort((edgeOne, edgeTwo) => edgeOne.Weight.CompareTo(edgeTwo.Weight));

            while (promisingEdges.Count != circleGraph.VertexList.Count - 1)
            {
                selectedEdge = candidateEdges[0];

                originConnectedComponent = connectedComponents.Find(ConnectedComponent => ConnectedComponent.VertexList.Contains(selectedEdge.Origin));
                destinationConnectedComponent = connectedComponents.Find(ConnectedComponent => ConnectedComponent.VertexList.Contains(selectedEdge.Destination));

                if (originConnectedComponent != destinationConnectedComponent)
                {
                    promisingEdges.Add(selectedEdge);

                    originConnectedComponent.VertexList.AddRange(destinationConnectedComponent.VertexList);

                    connectedComponents.Remove(destinationConnectedComponent);
                }

                candidateEdges.RemoveAt(0);

                if (candidateEdges.Count == 0)
                {
                    break;
                }
            }

            foreach (ConnectedComponent currentConnectedComponent in connectedComponents)
            {
                emptyVertexes.AddRange(currentConnectedComponent.VertexList);
            }

            kruskalMST = new Graph(emptyVertexes, promisingEdges);

            LabelNumberOfMSTSubgraphsValue.Text = connectedComponents.Count.ToString();

            return promisingEdges;
        }

        private void DrawMSTWithPrim(Vertex originVertex)
        {
            List<Edge> solutionEdges = BuildMSTWithPrim(originVertex);

            foreach (Edge currentEdge in solutionEdges)
            {
                DrawLine(currentEdge.Origin.VertexCircle.Centre, currentEdge.Destination.VertexCircle.Centre, Color.MediumTurquoise, PrimMSTPenWidth);
            }

            LabelPrimMSTTotalWeightValue.Text = primMST.GetTotalWeight().ToString();

            PictureBoxImage.Refresh();

            using (FormMSTSolutionSet MSTSolutionSetForm = new FormMSTSolutionSet(solutionEdges, "Prim"))
            {
                MSTSolutionSetForm.ShowDialog();
            }
        }

        private List<Edge> BuildMSTWithPrim(Vertex originVertex)
        {
            List<Edge> candidateEdges = originVertex.GetEdges(), promisingEdges = new List<Edge>();
            List<Vertex> MSTVertexes = new List<Vertex>() { new Vertex(originVertex.VertexCircle) };
            Edge selectedEdge;
            int numberOfSubgraphs = 1;

            candidateEdges.Sort(new CompareEdgesByWeight());

            while (promisingEdges.Count != circleGraph.VertexList.Count - 1)
            {
                if (candidateEdges.Count == 0)
                {
                    List<Vertex> remainingVertexes = circleGraph.VertexList.Except(MSTVertexes).ToList();

                    if (remainingVertexes.Count == 0)
                    {
                        break;
                    }

                    numberOfSubgraphs++;

                    AddEdgesToCandidateEdges(candidateEdges, remainingVertexes[0].GetEdges());

                    MSTVertexes.Add(new Vertex(remainingVertexes[0].VertexCircle));
                }

                selectedEdge = candidateEdges[0];

                if (ValidEdgeOnPrim(selectedEdge, MSTVertexes))
                {
                    promisingEdges.Add(selectedEdge);

                    if (MSTVertexes.Contains(selectedEdge.Origin))
                    {
                        MSTVertexes.Add(new Vertex(selectedEdge.Destination.VertexCircle));

                        AddEdgesToCandidateEdges(candidateEdges, selectedEdge.Destination.EdgeList);
                    }
                    else
                    {
                        MSTVertexes.Add(new Vertex(selectedEdge.Origin.VertexCircle));

                        AddEdgesToCandidateEdges(candidateEdges, selectedEdge.Origin.EdgeList);
                    }
                }

                candidateEdges.Remove(selectedEdge);
            }

            primMST = new Graph(MSTVertexes, promisingEdges);

            LabelNumberOfMSTSubgraphsValue.Text = numberOfSubgraphs.ToString();

            return promisingEdges;
        }

        private bool ValidEdgeOnPrim(Edge selectedEdge, List<Vertex> MSPVertexes)
        {
            if (MSPVertexes.Contains(selectedEdge.Origin))
            {
                if (MSPVertexes.Contains(selectedEdge.Destination))
                {
                    return false;
                }

                return true;
            }

            return true;
        }

        private void AddEdgesToCandidateEdges(List<Edge> candidateEdges, List<Edge> newCandidateEdges)
        {
            int currentEdgeIndex;

            foreach (Edge currentEdge in newCandidateEdges)
            {
                currentEdgeIndex = candidateEdges.BinarySearch(currentEdge, new CompareEdgesByWeight());

                if (currentEdgeIndex < 0)
                {
                    candidateEdges.Insert(~currentEdgeIndex, currentEdge);
                }
                else
                {
                    if (!candidateEdges.Contains(currentEdge))
                    {
                        candidateEdges.Insert(currentEdgeIndex, currentEdge);
                    }
                }
            }
        }

        private void FindClosestPairOfPointsByBruteForceOnImage()
        {
            CirclePair closestCirclePair = new CirclePair();
            double possibleMinimumDistance, minimumDistance = -1;

            bruteForceOnImageStopwatch = Stopwatch.StartNew();

            for (int i = 0; i < circleList.Count - 1; i++)
            {
                for (int j = i + 1; j < circleList.Count; j++)
                {
                    Thread.Sleep(1);

                    possibleMinimumDistance = EuclideanDistance(circleList[i].Centre, circleList[j].Centre);

                    if (possibleMinimumDistance < minimumDistance || minimumDistance == -1)
                    {
                        closestCirclePair.OriginCircle = circleList[i];
                        closestCirclePair.DestinationCircle = circleList[j];

                        minimumDistance = possibleMinimumDistance;
                    }
                }
            }

            bruteForceOnImageStopwatch.Stop();

            /**imageGraphics = Graphics.FromImage(closestPairOfPointsImage);**/

            DrawLine(closestCirclePair.OriginCircle.Centre, closestCirclePair.DestinationCircle.Centre, Color.LawnGreen, 20);

            DrawCircle(closestCirclePair.OriginCircle.Centre, 30, Color.LawnGreen);
            DrawCircle(closestCirclePair.DestinationCircle.Centre, 30, Color.LawnGreen);

            PictureBoxImage.Refresh();

            LabelBruteForceOnImageDistanceValue.Text = EuclideanDistance(closestCirclePair.OriginCircle.Centre, closestCirclePair.DestinationCircle.Centre).ToString();
        }

        private void FindClosestPairOfPointsByBruteForceOnGraph()
        {
            CirclePair closestCirclePair = new CirclePair();
            double possibleMinimumDistance, minimumDistance = -1;

            bruteForceOnGraphStopwatch = Stopwatch.StartNew();

            foreach (Vertex currentVertex in circleGraph.VertexList)
            {
                foreach (Edge currentEdge in currentVertex.EdgeList)
                {
                    if (currentEdge.Destination.VertexCircle.ID > currentVertex.VertexCircle.ID)
                    {
                        Thread.Sleep(1);

                        possibleMinimumDistance = currentEdge.Weight;

                        if (possibleMinimumDistance < minimumDistance || minimumDistance == -1)
                        {
                            closestCirclePair.OriginCircle = currentVertex.VertexCircle;
                            closestCirclePair.DestinationCircle = currentEdge.Destination.VertexCircle;

                            minimumDistance = possibleMinimumDistance;
                        }
                    }
                }
            }

            bruteForceOnGraphStopwatch.Stop();
            
            /**imageGraphics = Graphics.FromImage(closestPairOfPointsImage);**/

            DrawLine(closestCirclePair.OriginCircle.Centre, closestCirclePair.DestinationCircle.Centre, Color.Fuchsia, 10);

            DrawCircle(closestCirclePair.OriginCircle.Centre, 20, Color.Fuchsia);
            DrawCircle(closestCirclePair.DestinationCircle.Centre, 20, Color.Fuchsia);

            PictureBoxImage.Refresh();

            LabelBruteForceOnGraphDistanceValue.Text = EuclideanDistance(closestCirclePair.OriginCircle.Centre, closestCirclePair.DestinationCircle.Centre).ToString();
        }

        private void FindClosestPairOfPointsByDivideAndConquerOnImage()
        {
            List<Point> graphPoints = new List<Point>();
            Point[] closestPairOfPoints = new Point[2];

            foreach (Circle graphCircle in circleList)
            {
                graphPoints.Add(graphCircle.Centre);
            }

            graphPoints.Sort((pointOne, pointTwo) => pointOne.X.CompareTo(pointTwo.X));

            divideAndConquerOnImageStopwatch = Stopwatch.StartNew();

            closestPairOfPoints = DivideAndConquerGraphPoints(graphPoints);

            divideAndConquerOnImageStopwatch.Stop();

            /**imageGraphics = Graphics.FromImage(closestPairOfPointsImage);**/

            DrawLine(closestPairOfPoints[0], closestPairOfPoints[1], Color.Yellow, 3);

            DrawCircle(closestPairOfPoints[0], 10, Color.Yellow);
            DrawCircle(closestPairOfPoints[1], 10, Color.Yellow);

            PictureBoxImage.Refresh();

            LabelDivideAndConquerOnImageDistanceValue.Text = EuclideanDistance(closestPairOfPoints[0], closestPairOfPoints[1]).ToString();
        }

        private Point[] DivideAndConquerGraphPoints(List<Point> graphPoints)
        {
            Point[] closestPairOfPoints;
            double minimumDistance = double.PositiveInfinity, possibleMinimumDistance;

            // C
            if (graphPoints.Count <= 4)
            {
                closestPairOfPoints = new Point[2];

                for (int i = 0; i < graphPoints.Count - 1; i++)
                {
                    for (int j = i + 1; j < graphPoints.Count; j++)
                    {
                        Thread.Sleep(1);

                        possibleMinimumDistance = EuclideanDistance(graphPoints[i], graphPoints[j]);

                        if (possibleMinimumDistance < minimumDistance)
                        {
                            closestPairOfPoints[0] = graphPoints[i];
                            closestPairOfPoints[1] = graphPoints[j];

                            minimumDistance = possibleMinimumDistance;
                        }
                    }
                }

                return closestPairOfPoints;
            }

            List<Point> dGraphPoints = new List<Point>();
            Point[] leftSideClosestPairOfPoints, rightSideClosestPairOfPoints;
            Point middlePoint;
            int pointsCount, middle = graphPoints.Count / 2;
            double closestPairOfPointsDistance;

            middlePoint = graphPoints[middle];

            leftSideClosestPairOfPoints = DivideAndConquerGraphPoints(graphPoints.GetRange(0, middle));

            if (graphPoints.Count % 2 == 0)
            {
                pointsCount = middle - 1;
            }
            else
            {
                pointsCount = middle;
            }

            rightSideClosestPairOfPoints = DivideAndConquerGraphPoints(graphPoints.GetRange(middle + 1, pointsCount));

            if (EuclideanDistance(leftSideClosestPairOfPoints[0], leftSideClosestPairOfPoints[1]) < EuclideanDistance(rightSideClosestPairOfPoints[0], rightSideClosestPairOfPoints[1]))
            {
                closestPairOfPoints = leftSideClosestPairOfPoints;
            }
            else
            {
                closestPairOfPoints = rightSideClosestPairOfPoints;
            }

            closestPairOfPointsDistance = EuclideanDistance(closestPairOfPoints[0], closestPairOfPoints[1]);

            // O(n)
            for (int i = 0; i < graphPoints.Count; i++)
            {
                if (Math.Abs(graphPoints[i].X - middlePoint.X) < closestPairOfPointsDistance)
                {
                    dGraphPoints.Add(graphPoints[i]);
                }
            }

            // O(nlog(n))
            dGraphPoints.Sort((pointOne, pointTwo) => pointOne.Y.CompareTo(pointTwo.Y));

            minimumDistance = closestPairOfPointsDistance;

            // O(6n)
            for (int i = 0; i < dGraphPoints.Count - 1; i++)
            {
                for (int j = i + 1; j < dGraphPoints.Count; j++)
                {
                    if (dGraphPoints[j].Y - dGraphPoints[i].Y < minimumDistance)
                    {
                        Thread.Sleep(1);

                        possibleMinimumDistance = EuclideanDistance(dGraphPoints[i], dGraphPoints[j]);

                        if (possibleMinimumDistance < minimumDistance)
                        {
                            closestPairOfPoints[0] = dGraphPoints[i];
                            closestPairOfPoints[1] = dGraphPoints[j];

                            minimumDistance = possibleMinimumDistance;
                        }
                    }
                }
            }

            return closestPairOfPoints;
        }

        private bool BreadthFirstSearch(Vertex originVertex)
        {
            List<Vertex> visitedVertexes = new List<Vertex>() { originVertex };
            List<bool> treeVertexesNewLevel = new List<bool>() { false };
            Queue<Vertex> vertexQueue = new Queue<Vertex>();
            Vertex currentVertex, destinationVertex;
            int treeVertexesIndex = 0, vertexesAdded = 0;

            vertexQueue.Enqueue(originVertex);

            // O(N)
            while (vertexQueue.Count != 0)
            {
                currentVertex = vertexQueue.Dequeue();

                // O(N - 1)
                foreach (Edge currentEdge in currentVertex.EdgeList)
                {
                    destinationVertex = currentEdge.Destination;

                    if (!visitedVertexes.Contains(destinationVertex))
                    {
                        treeByBreadthPoints.Add(new Point[2] { currentVertex.VertexCircle.Centre, destinationVertex.VertexCircle.Centre });

                        visitedVertexes.Add(destinationVertex);
                        vertexQueue.Enqueue(destinationVertex);

                        vertexesAdded++;

                        if (!treeVertexesNewLevel[treeVertexesIndex])
                        {
                            treeVertexesNewLevel[treeVertexesIndex] = true;
                        }
                    }
                }

                if (treeVertexesIndex != 0)
                {
                    if (treeVertexesNewLevel[treeVertexesIndex - 1] != treeVertexesNewLevel[treeVertexesIndex])
                    {
                        return false;
                    }
                }

                treeVertexesIndex++;

                if (treeVertexesIndex == treeVertexesNewLevel.Count)
                {
                    treeVertexesNewLevel.Clear();

                    for (int i = 0; i < vertexesAdded; i++)
                    {
                        treeVertexesNewLevel.Add(false);
                    }

                    vertexesAdded = 0;
                    treeVertexesIndex = 0;
                }
            }

            return true;
        }

        private void ResetToolsAndAbstractDataTypes()
        {
            PictureBoxImage.BackgroundImage = null;

            // Main Graph
            circleGraph = null;

            circleList.Clear();
            circlePairList.Clear();

            TreeViewGraphDetails.Nodes.Clear();

            // Graph Tab
            TabControlCapabilities.SelectedIndex = (int)Tabs.Graph;

            // Points Tab
            if (closestPairOfPointsImage != null)
            {
                imageGraphics = Graphics.FromImage(closestPairOfPointsImage);
                imageGraphics.Clear(Color.Transparent);
            }

            ButtonFindClosestPairOfPoints.Enabled = false;

            LabelBruteForceOnImageExecutionTimeValue.Text = "0 ms";
            LabelBruteForceOnImageDistanceValue.Text = "0";
            LabelBruteForceOnGraphExecutionTimeValue.Text = "0 ms";
            LabelBruteForceOnGraphDistanceValue.Text = "0";
            LabelDivideAndConquerOnImageExecutionTimeValue.Text = "0 ms";
            LabelDivideAndConquerOnImageDistanceValue.Text = "0";

            // Random Tab
            if (agentsWithRandomPathImage != null)
            {
                imageGraphics = Graphics.FromImage(agentsWithRandomPathImage);
                imageGraphics.Clear(Color.Transparent);
            }

            TimerAgentsWithRandomPathMovement.Enabled = false;

            TreeViewAgentsWithRandomPathDetails.Nodes.Clear();

            NumericUpDownAgentsWithRandomPath.Value = NumericUpDownAgentsWithRandomPath.Minimum;
            NumericUpDownAgentsWithRandomPath.Enabled = false;

            ButtonCreateAgentsWithRandomPath.Enabled = false;

            // Trees Tab
            if (MSTImage != null)
            {
                imageGraphics = Graphics.FromImage(MSTImage);
                imageGraphics.Clear(Color.Transparent);
            }

            if (MSTAgentsImage != null)
            {
                imageGraphics = Graphics.FromImage(MSTAgentsImage);
                imageGraphics.Clear(Color.Transparent);
            }

            TimerMSTAgentsMovement.Enabled = false;

            TreeViewMSTAgentDetails.Nodes.Clear();

            NumericUpDownMSTAgents.Value = NumericUpDownMSTAgents.Minimum;
            NumericUpDownMSTAgents.Enabled = false;

            RadioButtonKruskal.Checked = true;
            RadioButtonKruskal.Enabled = false;
            RadioButtonPrim.Enabled = false;

            CheckBoxRandomOrigins.Checked = false;
            CheckBoxRandomOrigins.Enabled = false;

            ButtonGenerateMST.Enabled = false;
            ButtonCreateMSTAgents.Enabled = false;

            LabelPrimMSTTotalWeightValue.Text = "0";
            LabelKruskalMSTTotalWeightValue.Text = "0";
            LabelNumberOfMSTSubgraphsValue.Text = "0";

            // Preys Tab
            if (preysAndPredatorsImage != null)
            {
                imageGraphics = Graphics.FromImage(preysAndPredatorsImage);
                imageGraphics.Clear(Color.Transparent);
            }

            TimerPreysAndPredatorsMovement.Enabled = false;

            NumericUpDownPreys.Value = NumericUpDownPreys.Minimum;
            NumericUpDownPreys.Enabled = false;
            NumericUpDownPredators.Value = NumericUpDownPredators.Minimum;
            NumericUpDownPredators.Enabled = false;

            ButtonAddPreys.Enabled = false;
            ButtonAddPredators.Enabled = false;
            ButtonStart.Enabled = false;

            // Breadth Tab
            if (BFSTreeImage != null)
            {
                imageGraphics = Graphics.FromImage(BFSTreeImage);
                imageGraphics.Clear(Color.Transparent);
            }

            ButtonGenerateTreeByBreadth.Enabled = false;

            /**if (PictureBoxImage.BackgroundImage != null)
            {
                PictureBoxImage.BackgroundImage = null;
            }

            if (TimerAgentMovement.Enabled)
            {
                TimerAgentMovement.Enabled = false;
            }

            ButtonFindClosestPairOfPoints.Enabled = false;

            ButtonGenerateMST.Enabled = false;
            ButtonCreateMSTAgents.Enabled = false;

            NumericUpDownPredators.Value = NumericUpDownPredators.Minimum;
            NumericUpDownPredators.Enabled = false;
            ButtonAddPredators.Enabled = false;
            ButtonAddPreys.Enabled = false;
            ButtonStart.Enabled = false;

            ButtonGenerateTreeByBreadth.Enabled = false;

            TreeViewGraphDetails.Nodes.Clear();
            TreeViewMSTAgentDetails.Nodes.Clear();

            LabelNumberOfMSTSubgraphs.Text = "0";
            LabelKruskalMSTTotalWeightNumber.Text = "0";
            LabelPrimMSTTotalWeightNumber.Text = "0";

            NumericUpDownAgentsWithRandomPath.Value = NumericUpDownAgentsWithRandomPath.Minimum;
            NumericUpDownAgentsWithRandomPath.Enabled = false;
            ButtonCreateAgentsWithRandomPath.Enabled = false;
            TimerAgentsWithRandomPathMovement.Enabled = false;
            TreeViewAgentsWithRandomPathDetails.Nodes.Clear();

            MSTAgents.Clear();
            NumericUpDownMSTAgents.Value = NumericUpDownMSTAgents.Minimum;
            NumericUpDownMSTAgents.Enabled = false;

            globalPreys.Clear();
            NumericUpDownPreys.Value = NumericUpDownPreys.Minimum;
            NumericUpDownPreys.Enabled = false;

            if (circleGraph != null)
            {
                circleGraph = null;
            }

            if (kruskalMST != null)
            {
                kruskalMST = null;
            }

            if (primMST != null)
            {
                primMST = null;
            }

            if (dijkstraGraph != null)
            {
                dijkstraGraph = null;
            }

            circleList.Clear();
            circlePairList.Clear();
            globalPredators.Clear();**/
        }

        private void ProcessBitmap()
        {
            Point currentCoordinates = new Point();

            for (currentCoordinates.Y = 0; currentCoordinates.Y < processingImage.Height; currentCoordinates.Y++)
            {
                for (currentCoordinates.X = 0; currentCoordinates.X < processingImage.Width; currentCoordinates.X++)
                {
                    if (processingImage.GetPixel(currentCoordinates.X, currentCoordinates.Y).ToArgb() == Color.Black.ToArgb())
                    {
                        FindCircleCentre(ref currentCoordinates);
                    }
                }
            }
        }

        private void FindCircleCentre(ref Point currentCoordinates)
        {
            bool validCircleCentreSearch = true;
            int lastBlackPixelOnX = currentCoordinates.X + 1, middlePointOnX = 0, lastBlackPixelOnY = currentCoordinates.Y + 1, middlePointOnY = 0;

            try
            {
                while (processingImage.GetPixel(lastBlackPixelOnX, currentCoordinates.Y).ToArgb() == Color.Black.ToArgb())
                {
                    lastBlackPixelOnX++;
                }

                lastBlackPixelOnX--;

                middlePointOnX = (lastBlackPixelOnX + currentCoordinates.X) / 2;

                currentCoordinates.X = lastBlackPixelOnX;

                if (processingImage.GetPixel(middlePointOnX, currentCoordinates.Y - 1).ToArgb() == Color.Black.ToArgb())
                {
                    validCircleCentreSearch = false;
                }
                else
                {
                    while (processingImage.GetPixel(middlePointOnX, lastBlackPixelOnY).ToArgb() == Color.Black.ToArgb())
                    {
                        lastBlackPixelOnY++;
                    }

                    lastBlackPixelOnY--;

                    middlePointOnY = (lastBlackPixelOnY + currentCoordinates.Y) / 2;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                validCircleCentreSearch = false;
            }

            if (validCircleCentreSearch)
            {
                Point circleCentre = new Point(middlePointOnX, middlePointOnY);
                int circleRadius = (lastBlackPixelOnY - currentCoordinates.Y) / 2;

                if (IsFullCircle(circleCentre, circleRadius))
                {
                    Circle newCircle = new Circle(circleList.Count + 1, circleCentre, circleRadius);

                    circleList.Add(newCircle);
                }
            }

            currentCoordinates.X = lastBlackPixelOnX;
        }

        private bool IsFullCircle(Point circleCentre, int circleRadius)
        {
            try
            {
                if (processingImage.GetPixel(circleCentre.X - circleRadius - 2, circleCentre.Y).ToArgb() == Color.Black.ToArgb())
                {
                    return false;
                }

                if (processingImage.GetPixel(circleCentre.X + circleRadius + 2, circleCentre.Y).ToArgb() == Color.Black.ToArgb())
                {
                    return false;
                }

                if (processingImage.GetPixel(circleCentre.X, circleCentre.Y - circleRadius - 2).ToArgb() == Color.Black.ToArgb())
                {
                    return false;
                }

                if (processingImage.GetPixel(circleCentre.X, circleCentre.Y + circleRadius + 2).ToArgb() == Color.Black.ToArgb())
                {
                    return false;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            return true;
        }

        private void DrawCircleCentres()
        {
            Circle currentCircle;

            /**imageGraphics = Graphics.FromImage(processingImage);**/

            for (int i = 0; i < circleList.Count; i++)
            {
                currentCircle = circleList[i];

                DrawCircle(currentCircle.Centre, 8, Color.DarkOrange);

                imageGraphics.DrawString((i + 1).ToString(), new Font("Arial", 20), new SolidBrush(Color.Black),
                    currentCircle.Centre.X - currentCircle.Radius - 20, currentCircle.Centre.Y - currentCircle.Radius - 20);
            }
        
            PictureBoxImage.BackgroundImage = null;
            PictureBoxImage.BackgroundImage = processingImage;
        }

        private void DrawCircle(Point circleCentre, float circleDiameter, Color circleColor)
        {
            float circleRadius = circleDiameter / 2;

            imageGraphics.FillEllipse(new SolidBrush(circleColor), circleCentre.X - circleRadius, circleCentre.Y - circleRadius, circleDiameter, circleDiameter);
        }

        private void SetValidCirclePairs()
        {
            List<Point> linePoints;
            CirclePair validCirclePair;

            for (int i = 0; i < circleList.Count - 1; i++)
            {
                for (int j = i + 1; j < circleList.Count; j++)
                {
                    linePoints = new List<Point>();

                    if (ValidDrawLine(circleList[i].Centre, circleList[j].Centre, linePoints))
                    {
                        validCirclePair = new CirclePair(circleList[i], circleList[j], linePoints);

                        circlePairList.Add(validCirclePair);
                    }
                }
            }
        }

        private bool ValidDrawLine(Point originCentre, Point destinationCentre, List<Point> linePoints)
        {
            Point currentPixel, previousPixel, nextPixel;
            bool obstructionDetected = true, reversedOrigin = false;
            int originY, destinationY, originX, destinationX, numberOfObstructions = 1;

            if (originCentre.X == destinationCentre.X)
            {
                if (originCentre.Y < destinationCentre.Y)
                {
                    originY = originCentre.Y + 1;
                    destinationY = destinationCentre.Y;
                }
                else
                {
                    originY = destinationCentre.Y + 1;
                    destinationY = originCentre.Y;

                    reversedOrigin = true;
                }

                while (originY < destinationY)
                {
                    previousPixel = new Point(originCentre.X, originY - 1);
                    currentPixel = new Point(originCentre.X, originY);
                    nextPixel = new Point(originCentre.X, originY + 1);

                    if (ItsObstruction(previousPixel, currentPixel, nextPixel, ref obstructionDetected, ref numberOfObstructions))
                    {
                        return false;
                    }

                    linePoints.Add(currentPixel);

                    originY++;
                }
            }
            else
            {
                float m = (float)(destinationCentre.Y - originCentre.Y) / (destinationCentre.X - originCentre.X);
                float b = originCentre.Y - (m * originCentre.X);

                if (m > 1 || m < -1)
                {
                    if (originCentre.Y < destinationCentre.Y)
                    {
                        originY = originCentre.Y + 1;
                        destinationY = destinationCentre.Y;
                    }
                    else
                    {
                        originY = destinationCentre.Y + 1;
                        destinationY = originCentre.Y;

                        reversedOrigin = true;
                    }

                    while (originY < destinationY)
                    {
                        previousPixel = new Point((int)Math.Round((originY - 1 - b) / m), originY - 1);
                        currentPixel = new Point((int)Math.Round((originY - b) / m), originY);
                        nextPixel = new Point((int)Math.Round((originY + 1 - b) / m), originY + 1);

                        if (ItsObstruction(previousPixel, currentPixel, nextPixel, ref obstructionDetected, ref numberOfObstructions))
                        {
                            return false;
                        }

                        linePoints.Add(currentPixel);

                        originY++;
                    }
                }
                else
                {
                    if (originCentre.X < destinationCentre.X)
                    {
                        originX = originCentre.X + 1;
                        destinationX = destinationCentre.X;
                    }
                    else
                    {
                        originX = destinationCentre.X + 1;
                        destinationX = originCentre.X;

                        reversedOrigin = true;
                    }

                    while (originX < destinationX)
                    {
                        previousPixel = new Point(originX - 1, (int)Math.Round((m * (originX - 1)) + b));
                        currentPixel = new Point(originX, (int)Math.Round((m * originX) + b));
                        nextPixel = new Point(originX + 1, (int)Math.Round((m * (originX + 1)) + b));

                        if (ItsObstruction(previousPixel, currentPixel, nextPixel, ref obstructionDetected, ref numberOfObstructions))
                        {
                            return false;
                        }

                        linePoints.Add(currentPixel);

                        originX++;
                    }
                }
            }

            if (reversedOrigin)
            {
                linePoints.Reverse();
            }

            return true;
        }

        private bool ItsObstruction(Point previousPixel, Point currentPixel, Point nextPixel, ref bool obstructionDetected, ref int numberOfObstructions)
        {
            if (numberOfObstructions > 2)
            {
                return true;
            }

            List<Point> firstSide = new List<Point>(), secondSide = new List<Point>();
            Point surroundingPixel = new Point(currentPixel.X - 1, currentPixel.Y - 1), startingPixel = surroundingPixel;
            int movementCase = (int)SurroundingPixelMovement.UpperSide, listNumber = (int)SideLists.FirstSide;

            do
            {
                if (surroundingPixel == previousPixel || surroundingPixel == nextPixel)
                {
                    if (listNumber == (int)SideLists.FirstSide)
                    {
                        listNumber = (int)SideLists.SecondSide;
                    }
                    else
                    {
                        listNumber = (int)SideLists.FirstSide;
                    }
                }
                else
                {
                    if (listNumber == (int)SideLists.FirstSide)
                    {
                        firstSide.Add(surroundingPixel);
                    }
                    else
                    {
                        secondSide.Add(surroundingPixel);
                    }
                }

                switch (movementCase)
                {
                    case (int)SurroundingPixelMovement.UpperSide:

                        surroundingPixel.X++;

                        if (surroundingPixel.X == currentPixel.X + 1)
                        {
                            movementCase++;
                        }

                        break;

                    case (int)SurroundingPixelMovement.RightSide:

                        surroundingPixel.Y++;

                        if (surroundingPixel.Y == currentPixel.Y + 1)
                        {
                            movementCase++;
                        }

                        break;

                    case (int)SurroundingPixelMovement.LowerSide:

                        surroundingPixel.X--;

                        if (surroundingPixel.X == currentPixel.X - 1)
                        {
                            movementCase++;
                        }

                        break;

                    case (int)SurroundingPixelMovement.LeftSide:
                        surroundingPixel.Y--;
                        break;
                }
            }
            while (surroundingPixel != startingPixel);

            if (obstructionDetected)
            {
                if (ValidCentreAndSurroundings(currentPixel, firstSide, secondSide))
                {
                    obstructionDetected = false;
                }
            }
            else
            {
                if (!ValidCentreAndSurroundings(currentPixel, firstSide, secondSide))
                {
                    numberOfObstructions++;

                    obstructionDetected = true;
                }
            }

            return false;
        }

        private bool ValidCentreAndSurroundings(Point currentPixel, List<Point> firstSide, List<Point> secondSide)
        {
            if (processingImage.GetPixel(currentPixel.X, currentPixel.Y).ToArgb() != Color.White.ToArgb())
            {
                return false;
            }

            foreach (Point firstSidePoint in firstSide)
            {
                if (processingImage.GetPixel(firstSidePoint.X, firstSidePoint.Y).ToArgb() != Color.White.ToArgb())
                {
                    foreach (Point secondSidePoint in secondSide)
                    {
                        if (processingImage.GetPixel(secondSidePoint.X, secondSidePoint.Y).ToArgb() != Color.White.ToArgb())
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void UpdateGraphDetails()
        {
            int currentVertexNumber = 0, currentEdgeNumber;

            TreeViewGraphDetails.BeginUpdate();

            foreach (Vertex currentVertex in circleGraph.VertexList)
            {
                TreeViewGraphDetails.Nodes.Add(currentVertex.ToString());

                currentEdgeNumber = 0;

                foreach (Edge currentEdge in currentVertex.EdgeList)
                {
                    TreeViewGraphDetails.Nodes[currentVertexNumber].Nodes.Add(currentEdge.Destination.ToString());
                    TreeViewGraphDetails.Nodes[currentVertexNumber].Nodes[currentEdgeNumber].Nodes.Add(currentEdge.Weight.ToString());

                    currentEdgeNumber++;
                }

                currentVertexNumber++;
            }

            TreeViewGraphDetails.EndUpdate();
        }

        private void UpdateMSTAgentsDetails()
        {
            Agent currentAgent;
            string agentPath;

            TreeViewMSTAgentDetails.BeginUpdate();

            for (int i = 0; i < MSTAgents.Count; i++)
            {
                currentAgent = MSTAgents[i];

                TreeViewMSTAgentDetails.Nodes.Add(currentAgent.ID.ToString());

                agentPath = currentAgent.VisitedEdgeList[0].Origin.VertexCircle.ID.ToString();

                foreach (Edge currentEdge in currentAgent.VisitedEdgeList)
                {
                    agentPath += " → " + currentEdge.Destination.VertexCircle.ID.ToString();
                }

                TreeViewMSTAgentDetails.Nodes[i].Nodes.Add(agentPath);
            }

            TreeViewMSTAgentDetails.EndUpdate();

            /*string agentPath;

            TreeViewMSTAgentDetails.BeginUpdate();

            TreeViewMSTAgentDetails.Nodes.Add(globalAgent.ID.ToString());

            agentPath = globalAgent.VisitedEdgeList[0].Origin.VertexCircle.ID.ToString();

            foreach (Edge currentEdge in globalAgent.VisitedEdgeList)
            {
                agentPath += " → " + currentEdge.Destination.VertexCircle.ID.ToString();
            }

            TreeViewMSTAgentDetails.Nodes[0].Nodes.Add(agentPath);

            TreeViewMSTAgentDetails.EndUpdate();*/
        }

        private void UpdateAgentsWithRandomPathDetails()
        {
            string agentPath;
            int currentAgentNumber = 0, agentWithTheMostVisitedVertexesIndex = 0;

            TreeViewAgentsWithRandomPathDetails.BeginUpdate();

            foreach (Agent currentAgent in agentsWithRandomPath)
            {
                TreeViewAgentsWithRandomPathDetails.Nodes.Add(currentAgent.ID.ToString() + ". Vértices: " + currentAgent.VisitedVertexList.Count + ". Distancia: " + currentAgent.GetDistanceTraveled());

                agentPath = currentAgent.VisitedEdgeList[0].Origin.VertexCircle.ID.ToString();

                foreach (Edge currentEdge in currentAgent.VisitedEdgeList)
                {
                    agentPath += " → " + currentEdge.Destination.VertexCircle.ID.ToString();
                }

                TreeViewAgentsWithRandomPathDetails.Nodes[currentAgentNumber].Nodes.Add(agentPath);

                currentAgentNumber++;

                if (currentAgent.VisitedVertexList.Count > agentsWithRandomPath[agentWithTheMostVisitedVertexesIndex].VisitedVertexList.Count)
                {
                    agentWithTheMostVisitedVertexesIndex = currentAgent.ID - 1;
                }
                else if (currentAgent.VisitedVertexList.Count == agentsWithRandomPath[agentWithTheMostVisitedVertexesIndex].VisitedVertexList.Count)
                {
                    if (currentAgent.GetDistanceTraveled() > agentsWithRandomPath[agentWithTheMostVisitedVertexesIndex].GetDistanceTraveled())
                    {
                        agentWithTheMostVisitedVertexesIndex = currentAgent.ID - 1;
                    }
                }
            }

            TreeViewAgentsWithRandomPathDetails.Nodes[agentWithTheMostVisitedVertexesIndex].Text += " ← Mayor.";

            TreeViewAgentsWithRandomPathDetails.EndUpdate();
        }

        private void DrawCircleConnections()
        {
            /**imageGraphics = Graphics.FromImage(processingImage);**/

            foreach (CirclePair currentCirclePair in circlePairList)
            {
                DrawLine(currentCirclePair.OriginCircle.Centre, currentCirclePair.DestinationCircle.Centre, Color.OrangeRed, 2);
            }

            PictureBoxImage.BackgroundImage = null;
            PictureBoxImage.BackgroundImage = processingImage;
        }

        private void DrawLine(Point originPoint, Point destinationPoint, Color lineColor, float penWidth)
        {
            imageGraphics.DrawLine(new Pen(lineColor, penWidth), originPoint, destinationPoint);
        }

        private double EuclideanDistance(Point originPoint, Point destinationPoint)
        {
            return Math.Sqrt(Math.Pow(destinationPoint.X - originPoint.X, 2) + Math.Pow(destinationPoint.Y - originPoint.Y, 2));
        }
    }
}
