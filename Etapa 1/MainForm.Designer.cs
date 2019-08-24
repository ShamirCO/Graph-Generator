namespace Final_Project
{
    partial class FormFinalProject
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PictureBoxImage = new System.Windows.Forms.PictureBox();
            this.ButtonLoadImage = new System.Windows.Forms.Button();
            this.ButtonBuildGraph = new System.Windows.Forms.Button();
            this.OpenFileDialogLoadImage = new System.Windows.Forms.OpenFileDialog();
            this.TreeViewGraphDetails = new System.Windows.Forms.TreeView();
            this.LabelGraphDetails = new System.Windows.Forms.Label();
            this.ButtonFindClosestPairOfPoints = new System.Windows.Forms.Button();
            this.TimerPreysAndPredatorsMovement = new System.Windows.Forms.Timer(this.components);
            this.LabelMSTAgentDetails = new System.Windows.Forms.Label();
            this.TreeViewMSTAgentDetails = new System.Windows.Forms.TreeView();
            this.ButtonCreateMSTAgents = new System.Windows.Forms.Button();
            this.LabelNumberOfMSTSubgraphs = new System.Windows.Forms.Label();
            this.LabelNumberOfMSTSubgraphsValue = new System.Windows.Forms.Label();
            this.LabelKruskalMSTTotalWeight = new System.Windows.Forms.Label();
            this.LabelKruskalMSTTotalWeightValue = new System.Windows.Forms.Label();
            this.ButtonGenerateMST = new System.Windows.Forms.Button();
            this.LabelPrimMSTTotalWeightValue = new System.Windows.Forms.Label();
            this.LabelPrimMSTTotalWeight = new System.Windows.Forms.Label();
            this.GroupBoxMSTTotalWeight = new System.Windows.Forms.GroupBox();
            this.ButtonAddPreys = new System.Windows.Forms.Button();
            this.NumericUpDownPredators = new System.Windows.Forms.NumericUpDown();
            this.ButtonAddPredators = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonGenerateTreeByBreadth = new System.Windows.Forms.Button();
            this.ButtonCreateAgentsWithRandomPath = new System.Windows.Forms.Button();
            this.LabelAgentsWithRandomPath = new System.Windows.Forms.Label();
            this.NumericUpDownAgentsWithRandomPath = new System.Windows.Forms.NumericUpDown();
            this.TimerAgentsWithRandomPathMovement = new System.Windows.Forms.Timer(this.components);
            this.TreeViewAgentsWithRandomPathDetails = new System.Windows.Forms.TreeView();
            this.LabelMSTAgents = new System.Windows.Forms.Label();
            this.NumericUpDownMSTAgents = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownPreys = new System.Windows.Forms.NumericUpDown();
            this.LabelPreysAndPredators = new System.Windows.Forms.Label();
            this.CheckBoxRandomOrigins = new System.Windows.Forms.CheckBox();
            this.RadioButtonKruskal = new System.Windows.Forms.RadioButton();
            this.RadioButtonPrim = new System.Windows.Forms.RadioButton();
            this.TabControlCapabilities = new System.Windows.Forms.TabControl();
            this.TabPageGraph = new System.Windows.Forms.TabPage();
            this.TabPagePoints = new System.Windows.Forms.TabPage();
            this.GroupBoxDivideAndConquerOnImage = new System.Windows.Forms.GroupBox();
            this.LabelDivideAndConquerOnImageExecutionTimeValue = new System.Windows.Forms.Label();
            this.LabelDivideAndConquerOnImageDistanceValue = new System.Windows.Forms.Label();
            this.LabelDivideAndConquerOnImageExecutionTime = new System.Windows.Forms.Label();
            this.LabelDivideAndConquerOnImageColour = new System.Windows.Forms.Label();
            this.LabelDivideAndConquerOnImageDistance = new System.Windows.Forms.Label();
            this.GroupBoxBruteForceOnGraph = new System.Windows.Forms.GroupBox();
            this.LabelBruteForceOnGraphExecutionTimeValue = new System.Windows.Forms.Label();
            this.LabelBruteForceOnGraphDistanceValue = new System.Windows.Forms.Label();
            this.LabelBruteForceOnGraphExecutionTime = new System.Windows.Forms.Label();
            this.LabelBruteForceOnGraphColour = new System.Windows.Forms.Label();
            this.LabelBruteForceOnGraphDistance = new System.Windows.Forms.Label();
            this.GroupBoxBruteForceOnImage = new System.Windows.Forms.GroupBox();
            this.LabelBruteForceOnImageExecutionTimeValue = new System.Windows.Forms.Label();
            this.LabelBruteForceOnImageDistanceValue = new System.Windows.Forms.Label();
            this.LabelBruteForceOnImageExecutionTime = new System.Windows.Forms.Label();
            this.LabelBruteForceOnImageColour = new System.Windows.Forms.Label();
            this.LabelBruteForceOnImageDistance = new System.Windows.Forms.Label();
            this.TabPageRandom = new System.Windows.Forms.TabPage();
            this.TabPageTrees = new System.Windows.Forms.TabPage();
            this.TabPagePreys = new System.Windows.Forms.TabPage();
            this.TabPageBreadth = new System.Windows.Forms.TabPage();
            this.TimerMSTAgentsMovement = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxImage)).BeginInit();
            this.GroupBoxMSTTotalWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPredators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownAgentsWithRandomPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownMSTAgents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPreys)).BeginInit();
            this.TabControlCapabilities.SuspendLayout();
            this.TabPageGraph.SuspendLayout();
            this.TabPagePoints.SuspendLayout();
            this.GroupBoxDivideAndConquerOnImage.SuspendLayout();
            this.GroupBoxBruteForceOnGraph.SuspendLayout();
            this.GroupBoxBruteForceOnImage.SuspendLayout();
            this.TabPageRandom.SuspendLayout();
            this.TabPageTrees.SuspendLayout();
            this.TabPagePreys.SuspendLayout();
            this.TabPageBreadth.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBoxImage
            // 
            this.PictureBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBoxImage.Location = new System.Drawing.Point(12, 10);
            this.PictureBoxImage.Name = "PictureBoxImage";
            this.PictureBoxImage.Size = new System.Drawing.Size(660, 434);
            this.PictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxImage.TabIndex = 0;
            this.PictureBoxImage.TabStop = false;
            // 
            // ButtonLoadImage
            // 
            this.ButtonLoadImage.Location = new System.Drawing.Point(681, 382);
            this.ButtonLoadImage.Name = "ButtonLoadImage";
            this.ButtonLoadImage.Size = new System.Drawing.Size(165, 62);
            this.ButtonLoadImage.TabIndex = 1;
            this.ButtonLoadImage.Text = "Cargar Imagen";
            this.ButtonLoadImage.UseVisualStyleBackColor = true;
            this.ButtonLoadImage.Click += new System.EventHandler(this.ButtonLoadImage_Click);
            // 
            // ButtonBuildGraph
            // 
            this.ButtonBuildGraph.Location = new System.Drawing.Point(852, 382);
            this.ButtonBuildGraph.Name = "ButtonBuildGraph";
            this.ButtonBuildGraph.Size = new System.Drawing.Size(165, 62);
            this.ButtonBuildGraph.TabIndex = 2;
            this.ButtonBuildGraph.Text = "Construir Grafo";
            this.ButtonBuildGraph.UseVisualStyleBackColor = true;
            this.ButtonBuildGraph.Click += new System.EventHandler(this.ButtonBuildGraph_Click);
            // 
            // TreeViewGraphDetails
            // 
            this.TreeViewGraphDetails.Location = new System.Drawing.Point(6, 18);
            this.TreeViewGraphDetails.Name = "TreeViewGraphDetails";
            this.TreeViewGraphDetails.Size = new System.Drawing.Size(319, 319);
            this.TreeViewGraphDetails.TabIndex = 3;
            // 
            // LabelGraphDetails
            // 
            this.LabelGraphDetails.AutoSize = true;
            this.LabelGraphDetails.Location = new System.Drawing.Point(3, 3);
            this.LabelGraphDetails.Name = "LabelGraphDetails";
            this.LabelGraphDetails.Size = new System.Drawing.Size(84, 13);
            this.LabelGraphDetails.TabIndex = 4;
            this.LabelGraphDetails.Text = "Datos del Grafo:";
            // 
            // ButtonFindClosestPairOfPoints
            // 
            this.ButtonFindClosestPairOfPoints.Location = new System.Drawing.Point(6, 6);
            this.ButtonFindClosestPairOfPoints.Name = "ButtonFindClosestPairOfPoints";
            this.ButtonFindClosestPairOfPoints.Size = new System.Drawing.Size(319, 23);
            this.ButtonFindClosestPairOfPoints.TabIndex = 5;
            this.ButtonFindClosestPairOfPoints.Text = "Encontrar Puntos Más Cercanos";
            this.ButtonFindClosestPairOfPoints.UseVisualStyleBackColor = true;
            this.ButtonFindClosestPairOfPoints.Click += new System.EventHandler(this.ButtonFindClosestPairOfPoints_Click);
            // 
            // TimerPreysAndPredatorsMovement
            // 
            this.TimerPreysAndPredatorsMovement.Interval = 30;
            this.TimerPreysAndPredatorsMovement.Tick += new System.EventHandler(this.TimerPreysAndPredatorsMovement_Tick);
            // 
            // LabelMSTAgentDetails
            // 
            this.LabelMSTAgentDetails.AutoSize = true;
            this.LabelMSTAgentDetails.Location = new System.Drawing.Point(6, 165);
            this.LabelMSTAgentDetails.Name = "LabelMSTAgentDetails";
            this.LabelMSTAgentDetails.Size = new System.Drawing.Size(155, 13);
            this.LabelMSTAgentDetails.TabIndex = 9;
            this.LabelMSTAgentDetails.Text = "Datos de los Agentes del ARM:";
            // 
            // TreeViewMSTAgentDetails
            // 
            this.TreeViewMSTAgentDetails.Location = new System.Drawing.Point(9, 181);
            this.TreeViewMSTAgentDetails.Name = "TreeViewMSTAgentDetails";
            this.TreeViewMSTAgentDetails.Size = new System.Drawing.Size(316, 153);
            this.TreeViewMSTAgentDetails.TabIndex = 10;
            // 
            // ButtonCreateMSTAgents
            // 
            this.ButtonCreateMSTAgents.Location = new System.Drawing.Point(9, 139);
            this.ButtonCreateMSTAgents.Name = "ButtonCreateMSTAgents";
            this.ButtonCreateMSTAgents.Size = new System.Drawing.Size(316, 23);
            this.ButtonCreateMSTAgents.TabIndex = 14;
            this.ButtonCreateMSTAgents.Text = "Crear Agentes";
            this.ButtonCreateMSTAgents.UseVisualStyleBackColor = true;
            this.ButtonCreateMSTAgents.Click += new System.EventHandler(this.ButtonCreateMSTAgents_Click);
            // 
            // LabelNumberOfMSTSubgraphs
            // 
            this.LabelNumberOfMSTSubgraphs.AutoSize = true;
            this.LabelNumberOfMSTSubgraphs.Location = new System.Drawing.Point(163, 35);
            this.LabelNumberOfMSTSubgraphs.Name = "LabelNumberOfMSTSubgraphs";
            this.LabelNumberOfMSTSubgraphs.Size = new System.Drawing.Size(158, 13);
            this.LabelNumberOfMSTSubgraphs.TabIndex = 15;
            this.LabelNumberOfMSTSubgraphs.Text = "Número de Subgrafos en ARM: ";
            // 
            // LabelNumberOfMSTSubgraphsValue
            // 
            this.LabelNumberOfMSTSubgraphsValue.AutoSize = true;
            this.LabelNumberOfMSTSubgraphsValue.Location = new System.Drawing.Point(313, 35);
            this.LabelNumberOfMSTSubgraphsValue.Name = "LabelNumberOfMSTSubgraphsValue";
            this.LabelNumberOfMSTSubgraphsValue.Size = new System.Drawing.Size(13, 13);
            this.LabelNumberOfMSTSubgraphsValue.TabIndex = 16;
            this.LabelNumberOfMSTSubgraphsValue.Text = "0";
            // 
            // LabelKruskalMSTTotalWeight
            // 
            this.LabelKruskalMSTTotalWeight.AutoSize = true;
            this.LabelKruskalMSTTotalWeight.Location = new System.Drawing.Point(6, 38);
            this.LabelKruskalMSTTotalWeight.Name = "LabelKruskalMSTTotalWeight";
            this.LabelKruskalMSTTotalWeight.Size = new System.Drawing.Size(45, 13);
            this.LabelKruskalMSTTotalWeight.TabIndex = 17;
            this.LabelKruskalMSTTotalWeight.Text = "Kruskal:";
            // 
            // LabelKruskalMSTTotalWeightValue
            // 
            this.LabelKruskalMSTTotalWeightValue.AutoSize = true;
            this.LabelKruskalMSTTotalWeightValue.Location = new System.Drawing.Point(46, 38);
            this.LabelKruskalMSTTotalWeightValue.Name = "LabelKruskalMSTTotalWeightValue";
            this.LabelKruskalMSTTotalWeightValue.Size = new System.Drawing.Size(13, 13);
            this.LabelKruskalMSTTotalWeightValue.TabIndex = 18;
            this.LabelKruskalMSTTotalWeightValue.Text = "0";
            // 
            // ButtonGenerateMST
            // 
            this.ButtonGenerateMST.Location = new System.Drawing.Point(6, 6);
            this.ButtonGenerateMST.Name = "ButtonGenerateMST";
            this.ButtonGenerateMST.Size = new System.Drawing.Size(319, 23);
            this.ButtonGenerateMST.TabIndex = 19;
            this.ButtonGenerateMST.Text = "Generar ARM";
            this.ButtonGenerateMST.UseVisualStyleBackColor = true;
            this.ButtonGenerateMST.Click += new System.EventHandler(this.ButtonGenerateMST_Click);
            // 
            // LabelPrimMSTTotalWeightValue
            // 
            this.LabelPrimMSTTotalWeightValue.AutoSize = true;
            this.LabelPrimMSTTotalWeightValue.Location = new System.Drawing.Point(31, 16);
            this.LabelPrimMSTTotalWeightValue.Name = "LabelPrimMSTTotalWeightValue";
            this.LabelPrimMSTTotalWeightValue.Size = new System.Drawing.Size(13, 13);
            this.LabelPrimMSTTotalWeightValue.TabIndex = 21;
            this.LabelPrimMSTTotalWeightValue.Text = "0";
            // 
            // LabelPrimMSTTotalWeight
            // 
            this.LabelPrimMSTTotalWeight.AutoSize = true;
            this.LabelPrimMSTTotalWeight.Location = new System.Drawing.Point(6, 16);
            this.LabelPrimMSTTotalWeight.Name = "LabelPrimMSTTotalWeight";
            this.LabelPrimMSTTotalWeight.Size = new System.Drawing.Size(30, 13);
            this.LabelPrimMSTTotalWeight.TabIndex = 20;
            this.LabelPrimMSTTotalWeight.Text = "Prim:";
            // 
            // GroupBoxMSTTotalWeight
            // 
            this.GroupBoxMSTTotalWeight.Controls.Add(this.LabelPrimMSTTotalWeightValue);
            this.GroupBoxMSTTotalWeight.Controls.Add(this.LabelPrimMSTTotalWeight);
            this.GroupBoxMSTTotalWeight.Controls.Add(this.LabelKruskalMSTTotalWeightValue);
            this.GroupBoxMSTTotalWeight.Controls.Add(this.LabelKruskalMSTTotalWeight);
            this.GroupBoxMSTTotalWeight.Location = new System.Drawing.Point(9, 35);
            this.GroupBoxMSTTotalWeight.Name = "GroupBoxMSTTotalWeight";
            this.GroupBoxMSTTotalWeight.Size = new System.Drawing.Size(152, 59);
            this.GroupBoxMSTTotalWeight.TabIndex = 22;
            this.GroupBoxMSTTotalWeight.TabStop = false;
            this.GroupBoxMSTTotalWeight.Text = "Peso Total del ARM";
            // 
            // ButtonAddPreys
            // 
            this.ButtonAddPreys.Location = new System.Drawing.Point(6, 45);
            this.ButtonAddPreys.Name = "ButtonAddPreys";
            this.ButtonAddPreys.Size = new System.Drawing.Size(156, 23);
            this.ButtonAddPreys.TabIndex = 23;
            this.ButtonAddPreys.Text = "Agregar Presas";
            this.ButtonAddPreys.UseVisualStyleBackColor = true;
            this.ButtonAddPreys.Click += new System.EventHandler(this.ButtonAddPrey_Click);
            // 
            // NumericUpDownPredators
            // 
            this.NumericUpDownPredators.Location = new System.Drawing.Point(169, 19);
            this.NumericUpDownPredators.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NumericUpDownPredators.Name = "NumericUpDownPredators";
            this.NumericUpDownPredators.Size = new System.Drawing.Size(156, 20);
            this.NumericUpDownPredators.TabIndex = 24;
            // 
            // ButtonAddPredators
            // 
            this.ButtonAddPredators.Location = new System.Drawing.Point(169, 45);
            this.ButtonAddPredators.Name = "ButtonAddPredators";
            this.ButtonAddPredators.Size = new System.Drawing.Size(156, 23);
            this.ButtonAddPredators.TabIndex = 25;
            this.ButtonAddPredators.Text = "Agregar Depredadores";
            this.ButtonAddPredators.UseVisualStyleBackColor = true;
            this.ButtonAddPredators.Click += new System.EventHandler(this.ButtonAddPredators_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(6, 74);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(319, 23);
            this.ButtonStart.TabIndex = 26;
            this.ButtonStart.Text = "Iniciar";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ButtonGenerateTreeByBreadth
            // 
            this.ButtonGenerateTreeByBreadth.Location = new System.Drawing.Point(6, 6);
            this.ButtonGenerateTreeByBreadth.Name = "ButtonGenerateTreeByBreadth";
            this.ButtonGenerateTreeByBreadth.Size = new System.Drawing.Size(319, 23);
            this.ButtonGenerateTreeByBreadth.TabIndex = 27;
            this.ButtonGenerateTreeByBreadth.Text = "Generar Arbol En Amplitud";
            this.ButtonGenerateTreeByBreadth.UseVisualStyleBackColor = true;
            this.ButtonGenerateTreeByBreadth.Click += new System.EventHandler(this.ButtonGenerateTreeByBreadth_Click);
            // 
            // ButtonCreateAgentsWithRandomPath
            // 
            this.ButtonCreateAgentsWithRandomPath.Location = new System.Drawing.Point(6, 45);
            this.ButtonCreateAgentsWithRandomPath.Name = "ButtonCreateAgentsWithRandomPath";
            this.ButtonCreateAgentsWithRandomPath.Size = new System.Drawing.Size(319, 23);
            this.ButtonCreateAgentsWithRandomPath.TabIndex = 30;
            this.ButtonCreateAgentsWithRandomPath.Text = "Crear Agentes";
            this.ButtonCreateAgentsWithRandomPath.UseVisualStyleBackColor = true;
            this.ButtonCreateAgentsWithRandomPath.Click += new System.EventHandler(this.ButtonCreateAgentsWithRandomPath_Click);
            // 
            // LabelAgentsWithRandomPath
            // 
            this.LabelAgentsWithRandomPath.AutoSize = true;
            this.LabelAgentsWithRandomPath.Location = new System.Drawing.Point(6, 3);
            this.LabelAgentsWithRandomPath.Name = "LabelAgentsWithRandomPath";
            this.LabelAgentsWithRandomPath.Size = new System.Drawing.Size(152, 13);
            this.LabelAgentsWithRandomPath.TabIndex = 29;
            this.LabelAgentsWithRandomPath.Text = "Agentes con Camino Aleatorio:";
            // 
            // NumericUpDownAgentsWithRandomPath
            // 
            this.NumericUpDownAgentsWithRandomPath.Location = new System.Drawing.Point(6, 19);
            this.NumericUpDownAgentsWithRandomPath.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NumericUpDownAgentsWithRandomPath.Name = "NumericUpDownAgentsWithRandomPath";
            this.NumericUpDownAgentsWithRandomPath.Size = new System.Drawing.Size(319, 20);
            this.NumericUpDownAgentsWithRandomPath.TabIndex = 28;
            // 
            // TimerAgentsWithRandomPathMovement
            // 
            this.TimerAgentsWithRandomPathMovement.Interval = 30;
            this.TimerAgentsWithRandomPathMovement.Tick += new System.EventHandler(this.TimerAgentsWithRandomPathMovement_Tick);
            // 
            // TreeViewAgentsWithRandomPathDetails
            // 
            this.TreeViewAgentsWithRandomPathDetails.Location = new System.Drawing.Point(6, 73);
            this.TreeViewAgentsWithRandomPathDetails.Name = "TreeViewAgentsWithRandomPathDetails";
            this.TreeViewAgentsWithRandomPathDetails.Size = new System.Drawing.Size(319, 261);
            this.TreeViewAgentsWithRandomPathDetails.TabIndex = 32;
            // 
            // LabelMSTAgents
            // 
            this.LabelMSTAgents.AutoSize = true;
            this.LabelMSTAgents.Location = new System.Drawing.Point(6, 97);
            this.LabelMSTAgents.Name = "LabelMSTAgents";
            this.LabelMSTAgents.Size = new System.Drawing.Size(155, 13);
            this.LabelMSTAgents.TabIndex = 34;
            this.LabelMSTAgents.Text = "Agentes que Recorren el ARM:";
            // 
            // NumericUpDownMSTAgents
            // 
            this.NumericUpDownMSTAgents.Location = new System.Drawing.Point(9, 113);
            this.NumericUpDownMSTAgents.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NumericUpDownMSTAgents.Name = "NumericUpDownMSTAgents";
            this.NumericUpDownMSTAgents.Size = new System.Drawing.Size(81, 20);
            this.NumericUpDownMSTAgents.TabIndex = 33;
            // 
            // NumericUpDownPreys
            // 
            this.NumericUpDownPreys.Location = new System.Drawing.Point(6, 19);
            this.NumericUpDownPreys.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.NumericUpDownPreys.Name = "NumericUpDownPreys";
            this.NumericUpDownPreys.Size = new System.Drawing.Size(156, 20);
            this.NumericUpDownPreys.TabIndex = 35;
            // 
            // LabelPreysAndPredators
            // 
            this.LabelPreysAndPredators.AutoSize = true;
            this.LabelPreysAndPredators.Location = new System.Drawing.Point(3, 3);
            this.LabelPreysAndPredators.Name = "LabelPreysAndPredators";
            this.LabelPreysAndPredators.Size = new System.Drawing.Size(120, 13);
            this.LabelPreysAndPredators.TabIndex = 36;
            this.LabelPreysAndPredators.Text = "Presas y Depredadores:";
            // 
            // CheckBoxRandomOrigins
            // 
            this.CheckBoxRandomOrigins.AutoSize = true;
            this.CheckBoxRandomOrigins.Location = new System.Drawing.Point(213, 114);
            this.CheckBoxRandomOrigins.Name = "CheckBoxRandomOrigins";
            this.CheckBoxRandomOrigins.Size = new System.Drawing.Size(117, 17);
            this.CheckBoxRandomOrigins.TabIndex = 37;
            this.CheckBoxRandomOrigins.Text = "Origenes Aleatorios";
            this.CheckBoxRandomOrigins.UseVisualStyleBackColor = true;
            // 
            // RadioButtonKruskal
            // 
            this.RadioButtonKruskal.AutoSize = true;
            this.RadioButtonKruskal.Location = new System.Drawing.Point(96, 113);
            this.RadioButtonKruskal.Name = "RadioButtonKruskal";
            this.RadioButtonKruskal.Size = new System.Drawing.Size(60, 17);
            this.RadioButtonKruskal.TabIndex = 38;
            this.RadioButtonKruskal.TabStop = true;
            this.RadioButtonKruskal.Text = "Kruskal";
            this.RadioButtonKruskal.UseVisualStyleBackColor = true;
            // 
            // RadioButtonPrim
            // 
            this.RadioButtonPrim.AutoSize = true;
            this.RadioButtonPrim.Location = new System.Drawing.Point(162, 113);
            this.RadioButtonPrim.Name = "RadioButtonPrim";
            this.RadioButtonPrim.Size = new System.Drawing.Size(45, 17);
            this.RadioButtonPrim.TabIndex = 39;
            this.RadioButtonPrim.TabStop = true;
            this.RadioButtonPrim.Text = "Prim";
            this.RadioButtonPrim.UseVisualStyleBackColor = true;
            // 
            // TabControlCapabilities
            // 
            this.TabControlCapabilities.Controls.Add(this.TabPageGraph);
            this.TabControlCapabilities.Controls.Add(this.TabPagePoints);
            this.TabControlCapabilities.Controls.Add(this.TabPageRandom);
            this.TabControlCapabilities.Controls.Add(this.TabPageTrees);
            this.TabControlCapabilities.Controls.Add(this.TabPagePreys);
            this.TabControlCapabilities.Controls.Add(this.TabPageBreadth);
            this.TabControlCapabilities.Location = new System.Drawing.Point(678, 10);
            this.TabControlCapabilities.Name = "TabControlCapabilities";
            this.TabControlCapabilities.SelectedIndex = 0;
            this.TabControlCapabilities.Size = new System.Drawing.Size(339, 366);
            this.TabControlCapabilities.TabIndex = 40;
            this.TabControlCapabilities.Click += new System.EventHandler(this.TabControlCapabilities_Click);
            // 
            // TabPageGraph
            // 
            this.TabPageGraph.Controls.Add(this.LabelGraphDetails);
            this.TabPageGraph.Controls.Add(this.TreeViewGraphDetails);
            this.TabPageGraph.Location = new System.Drawing.Point(4, 22);
            this.TabPageGraph.Name = "TabPageGraph";
            this.TabPageGraph.Size = new System.Drawing.Size(331, 340);
            this.TabPageGraph.TabIndex = 5;
            this.TabPageGraph.Text = "Grafo";
            this.TabPageGraph.UseVisualStyleBackColor = true;
            // 
            // TabPagePoints
            // 
            this.TabPagePoints.Controls.Add(this.GroupBoxDivideAndConquerOnImage);
            this.TabPagePoints.Controls.Add(this.GroupBoxBruteForceOnGraph);
            this.TabPagePoints.Controls.Add(this.GroupBoxBruteForceOnImage);
            this.TabPagePoints.Controls.Add(this.ButtonFindClosestPairOfPoints);
            this.TabPagePoints.Location = new System.Drawing.Point(4, 22);
            this.TabPagePoints.Name = "TabPagePoints";
            this.TabPagePoints.Padding = new System.Windows.Forms.Padding(3);
            this.TabPagePoints.Size = new System.Drawing.Size(331, 340);
            this.TabPagePoints.TabIndex = 2;
            this.TabPagePoints.Text = "Puntos";
            this.TabPagePoints.UseVisualStyleBackColor = true;
            // 
            // GroupBoxDivideAndConquerOnImage
            // 
            this.GroupBoxDivideAndConquerOnImage.Controls.Add(this.LabelDivideAndConquerOnImageExecutionTimeValue);
            this.GroupBoxDivideAndConquerOnImage.Controls.Add(this.LabelDivideAndConquerOnImageDistanceValue);
            this.GroupBoxDivideAndConquerOnImage.Controls.Add(this.LabelDivideAndConquerOnImageExecutionTime);
            this.GroupBoxDivideAndConquerOnImage.Controls.Add(this.LabelDivideAndConquerOnImageColour);
            this.GroupBoxDivideAndConquerOnImage.Controls.Add(this.LabelDivideAndConquerOnImageDistance);
            this.GroupBoxDivideAndConquerOnImage.Location = new System.Drawing.Point(6, 189);
            this.GroupBoxDivideAndConquerOnImage.Name = "GroupBoxDivideAndConquerOnImage";
            this.GroupBoxDivideAndConquerOnImage.Size = new System.Drawing.Size(319, 71);
            this.GroupBoxDivideAndConquerOnImage.TabIndex = 27;
            this.GroupBoxDivideAndConquerOnImage.TabStop = false;
            this.GroupBoxDivideAndConquerOnImage.Text = "Divide y Vencerás en Imagen";
            // 
            // LabelDivideAndConquerOnImageExecutionTimeValue
            // 
            this.LabelDivideAndConquerOnImageExecutionTimeValue.AutoSize = true;
            this.LabelDivideAndConquerOnImageExecutionTimeValue.Location = new System.Drawing.Point(111, 33);
            this.LabelDivideAndConquerOnImageExecutionTimeValue.Name = "LabelDivideAndConquerOnImageExecutionTimeValue";
            this.LabelDivideAndConquerOnImageExecutionTimeValue.Size = new System.Drawing.Size(29, 13);
            this.LabelDivideAndConquerOnImageExecutionTimeValue.TabIndex = 25;
            this.LabelDivideAndConquerOnImageExecutionTimeValue.Text = "0 ms";
            // 
            // LabelDivideAndConquerOnImageDistanceValue
            // 
            this.LabelDivideAndConquerOnImageDistanceValue.AutoSize = true;
            this.LabelDivideAndConquerOnImageDistanceValue.Location = new System.Drawing.Point(55, 50);
            this.LabelDivideAndConquerOnImageDistanceValue.Name = "LabelDivideAndConquerOnImageDistanceValue";
            this.LabelDivideAndConquerOnImageDistanceValue.Size = new System.Drawing.Size(13, 13);
            this.LabelDivideAndConquerOnImageDistanceValue.TabIndex = 1;
            this.LabelDivideAndConquerOnImageDistanceValue.Text = "0";
            // 
            // LabelDivideAndConquerOnImageExecutionTime
            // 
            this.LabelDivideAndConquerOnImageExecutionTime.AutoSize = true;
            this.LabelDivideAndConquerOnImageExecutionTime.Location = new System.Drawing.Point(6, 33);
            this.LabelDivideAndConquerOnImageExecutionTime.Name = "LabelDivideAndConquerOnImageExecutionTime";
            this.LabelDivideAndConquerOnImageExecutionTime.Size = new System.Drawing.Size(110, 13);
            this.LabelDivideAndConquerOnImageExecutionTime.TabIndex = 3;
            this.LabelDivideAndConquerOnImageExecutionTime.Text = "Tiempo de Ejecución:";
            // 
            // LabelDivideAndConquerOnImageColour
            // 
            this.LabelDivideAndConquerOnImageColour.AutoSize = true;
            this.LabelDivideAndConquerOnImageColour.Location = new System.Drawing.Point(6, 16);
            this.LabelDivideAndConquerOnImageColour.Name = "LabelDivideAndConquerOnImageColour";
            this.LabelDivideAndConquerOnImageColour.Size = new System.Drawing.Size(73, 13);
            this.LabelDivideAndConquerOnImageColour.TabIndex = 2;
            this.LabelDivideAndConquerOnImageColour.Text = "Color: Amarillo";
            // 
            // LabelDivideAndConquerOnImageDistance
            // 
            this.LabelDivideAndConquerOnImageDistance.AutoSize = true;
            this.LabelDivideAndConquerOnImageDistance.Location = new System.Drawing.Point(6, 50);
            this.LabelDivideAndConquerOnImageDistance.Name = "LabelDivideAndConquerOnImageDistance";
            this.LabelDivideAndConquerOnImageDistance.Size = new System.Drawing.Size(54, 13);
            this.LabelDivideAndConquerOnImageDistance.TabIndex = 0;
            this.LabelDivideAndConquerOnImageDistance.Text = "Distancia:";
            // 
            // GroupBoxBruteForceOnGraph
            // 
            this.GroupBoxBruteForceOnGraph.Controls.Add(this.LabelBruteForceOnGraphExecutionTimeValue);
            this.GroupBoxBruteForceOnGraph.Controls.Add(this.LabelBruteForceOnGraphDistanceValue);
            this.GroupBoxBruteForceOnGraph.Controls.Add(this.LabelBruteForceOnGraphExecutionTime);
            this.GroupBoxBruteForceOnGraph.Controls.Add(this.LabelBruteForceOnGraphColour);
            this.GroupBoxBruteForceOnGraph.Controls.Add(this.LabelBruteForceOnGraphDistance);
            this.GroupBoxBruteForceOnGraph.Location = new System.Drawing.Point(6, 112);
            this.GroupBoxBruteForceOnGraph.Name = "GroupBoxBruteForceOnGraph";
            this.GroupBoxBruteForceOnGraph.Size = new System.Drawing.Size(319, 71);
            this.GroupBoxBruteForceOnGraph.TabIndex = 26;
            this.GroupBoxBruteForceOnGraph.TabStop = false;
            this.GroupBoxBruteForceOnGraph.Text = "Fuerza Bruta en Grafo";
            // 
            // LabelBruteForceOnGraphExecutionTimeValue
            // 
            this.LabelBruteForceOnGraphExecutionTimeValue.AutoSize = true;
            this.LabelBruteForceOnGraphExecutionTimeValue.Location = new System.Drawing.Point(111, 33);
            this.LabelBruteForceOnGraphExecutionTimeValue.Name = "LabelBruteForceOnGraphExecutionTimeValue";
            this.LabelBruteForceOnGraphExecutionTimeValue.Size = new System.Drawing.Size(29, 13);
            this.LabelBruteForceOnGraphExecutionTimeValue.TabIndex = 25;
            this.LabelBruteForceOnGraphExecutionTimeValue.Text = "0 ms";
            // 
            // LabelBruteForceOnGraphDistanceValue
            // 
            this.LabelBruteForceOnGraphDistanceValue.AutoSize = true;
            this.LabelBruteForceOnGraphDistanceValue.Location = new System.Drawing.Point(55, 50);
            this.LabelBruteForceOnGraphDistanceValue.Name = "LabelBruteForceOnGraphDistanceValue";
            this.LabelBruteForceOnGraphDistanceValue.Size = new System.Drawing.Size(13, 13);
            this.LabelBruteForceOnGraphDistanceValue.TabIndex = 1;
            this.LabelBruteForceOnGraphDistanceValue.Text = "0";
            // 
            // LabelBruteForceOnGraphExecutionTime
            // 
            this.LabelBruteForceOnGraphExecutionTime.AutoSize = true;
            this.LabelBruteForceOnGraphExecutionTime.Location = new System.Drawing.Point(6, 33);
            this.LabelBruteForceOnGraphExecutionTime.Name = "LabelBruteForceOnGraphExecutionTime";
            this.LabelBruteForceOnGraphExecutionTime.Size = new System.Drawing.Size(110, 13);
            this.LabelBruteForceOnGraphExecutionTime.TabIndex = 3;
            this.LabelBruteForceOnGraphExecutionTime.Text = "Tiempo de Ejecución:";
            // 
            // LabelBruteForceOnGraphColour
            // 
            this.LabelBruteForceOnGraphColour.AutoSize = true;
            this.LabelBruteForceOnGraphColour.Location = new System.Drawing.Point(6, 16);
            this.LabelBruteForceOnGraphColour.Name = "LabelBruteForceOnGraphColour";
            this.LabelBruteForceOnGraphColour.Size = new System.Drawing.Size(73, 13);
            this.LabelBruteForceOnGraphColour.TabIndex = 2;
            this.LabelBruteForceOnGraphColour.Text = "Color: Morado";
            // 
            // LabelBruteForceOnGraphDistance
            // 
            this.LabelBruteForceOnGraphDistance.AutoSize = true;
            this.LabelBruteForceOnGraphDistance.Location = new System.Drawing.Point(6, 50);
            this.LabelBruteForceOnGraphDistance.Name = "LabelBruteForceOnGraphDistance";
            this.LabelBruteForceOnGraphDistance.Size = new System.Drawing.Size(54, 13);
            this.LabelBruteForceOnGraphDistance.TabIndex = 0;
            this.LabelBruteForceOnGraphDistance.Text = "Distancia:";
            // 
            // GroupBoxBruteForceOnImage
            // 
            this.GroupBoxBruteForceOnImage.Controls.Add(this.LabelBruteForceOnImageExecutionTimeValue);
            this.GroupBoxBruteForceOnImage.Controls.Add(this.LabelBruteForceOnImageDistanceValue);
            this.GroupBoxBruteForceOnImage.Controls.Add(this.LabelBruteForceOnImageExecutionTime);
            this.GroupBoxBruteForceOnImage.Controls.Add(this.LabelBruteForceOnImageColour);
            this.GroupBoxBruteForceOnImage.Controls.Add(this.LabelBruteForceOnImageDistance);
            this.GroupBoxBruteForceOnImage.Location = new System.Drawing.Point(6, 35);
            this.GroupBoxBruteForceOnImage.Name = "GroupBoxBruteForceOnImage";
            this.GroupBoxBruteForceOnImage.Size = new System.Drawing.Size(319, 71);
            this.GroupBoxBruteForceOnImage.TabIndex = 24;
            this.GroupBoxBruteForceOnImage.TabStop = false;
            this.GroupBoxBruteForceOnImage.Text = "Fuerza Bruta en Imagen";
            // 
            // LabelBruteForceOnImageExecutionTimeValue
            // 
            this.LabelBruteForceOnImageExecutionTimeValue.AutoSize = true;
            this.LabelBruteForceOnImageExecutionTimeValue.Location = new System.Drawing.Point(111, 33);
            this.LabelBruteForceOnImageExecutionTimeValue.Name = "LabelBruteForceOnImageExecutionTimeValue";
            this.LabelBruteForceOnImageExecutionTimeValue.Size = new System.Drawing.Size(29, 13);
            this.LabelBruteForceOnImageExecutionTimeValue.TabIndex = 25;
            this.LabelBruteForceOnImageExecutionTimeValue.Text = "0 ms";
            // 
            // LabelBruteForceOnImageDistanceValue
            // 
            this.LabelBruteForceOnImageDistanceValue.AutoSize = true;
            this.LabelBruteForceOnImageDistanceValue.Location = new System.Drawing.Point(55, 50);
            this.LabelBruteForceOnImageDistanceValue.Name = "LabelBruteForceOnImageDistanceValue";
            this.LabelBruteForceOnImageDistanceValue.Size = new System.Drawing.Size(13, 13);
            this.LabelBruteForceOnImageDistanceValue.TabIndex = 1;
            this.LabelBruteForceOnImageDistanceValue.Text = "0";
            // 
            // LabelBruteForceOnImageExecutionTime
            // 
            this.LabelBruteForceOnImageExecutionTime.AutoSize = true;
            this.LabelBruteForceOnImageExecutionTime.Location = new System.Drawing.Point(6, 33);
            this.LabelBruteForceOnImageExecutionTime.Name = "LabelBruteForceOnImageExecutionTime";
            this.LabelBruteForceOnImageExecutionTime.Size = new System.Drawing.Size(110, 13);
            this.LabelBruteForceOnImageExecutionTime.TabIndex = 3;
            this.LabelBruteForceOnImageExecutionTime.Text = "Tiempo de Ejecución:";
            // 
            // LabelBruteForceOnImageColour
            // 
            this.LabelBruteForceOnImageColour.AutoSize = true;
            this.LabelBruteForceOnImageColour.Location = new System.Drawing.Point(6, 16);
            this.LabelBruteForceOnImageColour.Name = "LabelBruteForceOnImageColour";
            this.LabelBruteForceOnImageColour.Size = new System.Drawing.Size(65, 13);
            this.LabelBruteForceOnImageColour.TabIndex = 2;
            this.LabelBruteForceOnImageColour.Text = "Color: Verde";
            // 
            // LabelBruteForceOnImageDistance
            // 
            this.LabelBruteForceOnImageDistance.AutoSize = true;
            this.LabelBruteForceOnImageDistance.Location = new System.Drawing.Point(6, 50);
            this.LabelBruteForceOnImageDistance.Name = "LabelBruteForceOnImageDistance";
            this.LabelBruteForceOnImageDistance.Size = new System.Drawing.Size(54, 13);
            this.LabelBruteForceOnImageDistance.TabIndex = 0;
            this.LabelBruteForceOnImageDistance.Text = "Distancia:";
            // 
            // TabPageRandom
            // 
            this.TabPageRandom.Controls.Add(this.NumericUpDownAgentsWithRandomPath);
            this.TabPageRandom.Controls.Add(this.LabelAgentsWithRandomPath);
            this.TabPageRandom.Controls.Add(this.ButtonCreateAgentsWithRandomPath);
            this.TabPageRandom.Controls.Add(this.TreeViewAgentsWithRandomPathDetails);
            this.TabPageRandom.Location = new System.Drawing.Point(4, 22);
            this.TabPageRandom.Name = "TabPageRandom";
            this.TabPageRandom.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageRandom.Size = new System.Drawing.Size(331, 340);
            this.TabPageRandom.TabIndex = 0;
            this.TabPageRandom.Text = "Aleatorio";
            this.TabPageRandom.UseVisualStyleBackColor = true;
            // 
            // TabPageTrees
            // 
            this.TabPageTrees.Controls.Add(this.LabelNumberOfMSTSubgraphsValue);
            this.TabPageTrees.Controls.Add(this.CheckBoxRandomOrigins);
            this.TabPageTrees.Controls.Add(this.LabelMSTAgents);
            this.TabPageTrees.Controls.Add(this.ButtonGenerateMST);
            this.TabPageTrees.Controls.Add(this.NumericUpDownMSTAgents);
            this.TabPageTrees.Controls.Add(this.GroupBoxMSTTotalWeight);
            this.TabPageTrees.Controls.Add(this.LabelNumberOfMSTSubgraphs);
            this.TabPageTrees.Controls.Add(this.RadioButtonPrim);
            this.TabPageTrees.Controls.Add(this.LabelMSTAgentDetails);
            this.TabPageTrees.Controls.Add(this.RadioButtonKruskal);
            this.TabPageTrees.Controls.Add(this.TreeViewMSTAgentDetails);
            this.TabPageTrees.Controls.Add(this.ButtonCreateMSTAgents);
            this.TabPageTrees.Location = new System.Drawing.Point(4, 22);
            this.TabPageTrees.Name = "TabPageTrees";
            this.TabPageTrees.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageTrees.Size = new System.Drawing.Size(331, 340);
            this.TabPageTrees.TabIndex = 1;
            this.TabPageTrees.Text = "Arboles";
            this.TabPageTrees.UseVisualStyleBackColor = true;
            // 
            // TabPagePreys
            // 
            this.TabPagePreys.Controls.Add(this.LabelPreysAndPredators);
            this.TabPagePreys.Controls.Add(this.ButtonAddPreys);
            this.TabPagePreys.Controls.Add(this.NumericUpDownPredators);
            this.TabPagePreys.Controls.Add(this.NumericUpDownPreys);
            this.TabPagePreys.Controls.Add(this.ButtonAddPredators);
            this.TabPagePreys.Controls.Add(this.ButtonStart);
            this.TabPagePreys.Location = new System.Drawing.Point(4, 22);
            this.TabPagePreys.Name = "TabPagePreys";
            this.TabPagePreys.Padding = new System.Windows.Forms.Padding(3);
            this.TabPagePreys.Size = new System.Drawing.Size(331, 340);
            this.TabPagePreys.TabIndex = 3;
            this.TabPagePreys.Text = "Presas";
            this.TabPagePreys.UseVisualStyleBackColor = true;
            // 
            // TabPageBreadth
            // 
            this.TabPageBreadth.Controls.Add(this.ButtonGenerateTreeByBreadth);
            this.TabPageBreadth.Location = new System.Drawing.Point(4, 22);
            this.TabPageBreadth.Name = "TabPageBreadth";
            this.TabPageBreadth.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageBreadth.Size = new System.Drawing.Size(331, 340);
            this.TabPageBreadth.TabIndex = 4;
            this.TabPageBreadth.Text = "Amplitud";
            this.TabPageBreadth.UseVisualStyleBackColor = true;
            // 
            // TimerMSTAgentsMovement
            // 
            this.TimerMSTAgentsMovement.Interval = 30;
            this.TimerMSTAgentsMovement.Tick += new System.EventHandler(this.TimerMSTAgentsMovement_Tick);
            // 
            // FormFinalProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 456);
            this.Controls.Add(this.TabControlCapabilities);
            this.Controls.Add(this.ButtonBuildGraph);
            this.Controls.Add(this.ButtonLoadImage);
            this.Controls.Add(this.PictureBoxImage);
            this.Name = "FormFinalProject";
            this.Text = "Proyecto Final";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxImage)).EndInit();
            this.GroupBoxMSTTotalWeight.ResumeLayout(false);
            this.GroupBoxMSTTotalWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPredators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownAgentsWithRandomPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownMSTAgents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownPreys)).EndInit();
            this.TabControlCapabilities.ResumeLayout(false);
            this.TabPageGraph.ResumeLayout(false);
            this.TabPageGraph.PerformLayout();
            this.TabPagePoints.ResumeLayout(false);
            this.GroupBoxDivideAndConquerOnImage.ResumeLayout(false);
            this.GroupBoxDivideAndConquerOnImage.PerformLayout();
            this.GroupBoxBruteForceOnGraph.ResumeLayout(false);
            this.GroupBoxBruteForceOnGraph.PerformLayout();
            this.GroupBoxBruteForceOnImage.ResumeLayout(false);
            this.GroupBoxBruteForceOnImage.PerformLayout();
            this.TabPageRandom.ResumeLayout(false);
            this.TabPageRandom.PerformLayout();
            this.TabPageTrees.ResumeLayout(false);
            this.TabPageTrees.PerformLayout();
            this.TabPagePreys.ResumeLayout(false);
            this.TabPagePreys.PerformLayout();
            this.TabPageBreadth.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxImage;
        private System.Windows.Forms.Button ButtonLoadImage;
        private System.Windows.Forms.Button ButtonBuildGraph;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogLoadImage;
        private System.Windows.Forms.TreeView TreeViewGraphDetails;
        private System.Windows.Forms.Label LabelGraphDetails;
        private System.Windows.Forms.Button ButtonFindClosestPairOfPoints;
        private System.Windows.Forms.Timer TimerPreysAndPredatorsMovement;
        private System.Windows.Forms.Label LabelMSTAgentDetails;
        private System.Windows.Forms.TreeView TreeViewMSTAgentDetails;
        private System.Windows.Forms.Button ButtonCreateMSTAgents;
        private System.Windows.Forms.Label LabelNumberOfMSTSubgraphs;
        private System.Windows.Forms.Label LabelNumberOfMSTSubgraphsValue;
        private System.Windows.Forms.Label LabelKruskalMSTTotalWeight;
        private System.Windows.Forms.Label LabelKruskalMSTTotalWeightValue;
        private System.Windows.Forms.Button ButtonGenerateMST;
        private System.Windows.Forms.Label LabelPrimMSTTotalWeightValue;
        private System.Windows.Forms.Label LabelPrimMSTTotalWeight;
        private System.Windows.Forms.GroupBox GroupBoxMSTTotalWeight;
        private System.Windows.Forms.Button ButtonAddPreys;
        private System.Windows.Forms.NumericUpDown NumericUpDownPredators;
        private System.Windows.Forms.Button ButtonAddPredators;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonGenerateTreeByBreadth;
        private System.Windows.Forms.Button ButtonCreateAgentsWithRandomPath;
        private System.Windows.Forms.Label LabelAgentsWithRandomPath;
        private System.Windows.Forms.NumericUpDown NumericUpDownAgentsWithRandomPath;
        private System.Windows.Forms.Timer TimerAgentsWithRandomPathMovement;
        private System.Windows.Forms.TreeView TreeViewAgentsWithRandomPathDetails;
        private System.Windows.Forms.Label LabelMSTAgents;
        private System.Windows.Forms.NumericUpDown NumericUpDownMSTAgents;
        private System.Windows.Forms.NumericUpDown NumericUpDownPreys;
        private System.Windows.Forms.Label LabelPreysAndPredators;
        private System.Windows.Forms.CheckBox CheckBoxRandomOrigins;
        private System.Windows.Forms.RadioButton RadioButtonKruskal;
        private System.Windows.Forms.RadioButton RadioButtonPrim;
        private System.Windows.Forms.TabControl TabControlCapabilities;
        private System.Windows.Forms.TabPage TabPageRandom;
        private System.Windows.Forms.TabPage TabPageTrees;
        private System.Windows.Forms.TabPage TabPagePoints;
        private System.Windows.Forms.TabPage TabPagePreys;
        private System.Windows.Forms.TabPage TabPageBreadth;
        private System.Windows.Forms.TabPage TabPageGraph;
        private System.Windows.Forms.GroupBox GroupBoxBruteForceOnImage;
        private System.Windows.Forms.Label LabelBruteForceOnImageDistanceValue;
        private System.Windows.Forms.Label LabelBruteForceOnImageDistance;
        private System.Windows.Forms.Label LabelBruteForceOnImageColour;
        private System.Windows.Forms.Label LabelBruteForceOnImageExecutionTime;
        private System.Windows.Forms.Label LabelBruteForceOnImageExecutionTimeValue;
        private System.Windows.Forms.GroupBox GroupBoxBruteForceOnGraph;
        private System.Windows.Forms.Label LabelBruteForceOnGraphExecutionTimeValue;
        private System.Windows.Forms.Label LabelBruteForceOnGraphDistanceValue;
        private System.Windows.Forms.Label LabelBruteForceOnGraphExecutionTime;
        private System.Windows.Forms.Label LabelBruteForceOnGraphColour;
        private System.Windows.Forms.Label LabelBruteForceOnGraphDistance;
        private System.Windows.Forms.GroupBox GroupBoxDivideAndConquerOnImage;
        private System.Windows.Forms.Label LabelDivideAndConquerOnImageExecutionTimeValue;
        private System.Windows.Forms.Label LabelDivideAndConquerOnImageDistanceValue;
        private System.Windows.Forms.Label LabelDivideAndConquerOnImageExecutionTime;
        private System.Windows.Forms.Label LabelDivideAndConquerOnImageColour;
        private System.Windows.Forms.Label LabelDivideAndConquerOnImageDistance;
        private System.Windows.Forms.Timer TimerMSTAgentsMovement;
    }
}

