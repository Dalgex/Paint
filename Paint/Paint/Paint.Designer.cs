namespace Paint
{
    partial class Paint
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.buttonForBrush = new System.Windows.Forms.Button();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonForFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToSave = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.itemImageFormatPNG = new System.Windows.Forms.ToolStripMenuItem();
            this.itemImageFormatJPEG = new System.Windows.Forms.ToolStripMenuItem();
            this.itemImageFormatBMP = new System.Windows.Forms.ToolStripMenuItem();
            this.itemImageFormatGIF = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.buttonForEraser = new System.Windows.Forms.Button();
            this.buttonToPaste = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonForRotating = new System.Windows.Forms.ToolStripSplitButton();
            this.itemToRotate90 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToRotate270 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToRotate180 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToFlipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToFlipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonForEllipse = new System.Windows.Forms.Button();
            this.buttonForRectangle = new System.Windows.Forms.Button();
            this.buttonForLine = new System.Windows.Forms.Button();
            this.buttonForColorFilling = new System.Windows.Forms.Button();
            this.panelForBackgroundColor = new System.Windows.Forms.Panel();
            this.labelForBackgroundColor = new System.Windows.Forms.Label();
            this.pictureBoxForBackgroundColor = new System.Windows.Forms.PictureBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.panelForMainColor = new System.Windows.Forms.Panel();
            this.labelForMainColor = new System.Windows.Forms.Label();
            this.pictureBoxForMainColor = new System.Windows.Forms.PictureBox();
            this.buttonForPipette = new System.Windows.Forms.Button();
            this.buttonForUndo = new System.Windows.Forms.Button();
            this.buttonForRedo = new System.Windows.Forms.Button();
            this.panelForWidth = new System.Windows.Forms.Panel();
            this.labelForWidth = new System.Windows.Forms.Label();
            this.buttonForSelection = new System.Windows.Forms.Button();
            this.panelForForm = new System.Windows.Forms.Panel();
            this.panelForStatusBar = new System.Windows.Forms.TableLayoutPanel();
            this.labelForPictureBoxSize = new System.Windows.Forms.Label();
            this.labelForCursorLocation = new System.Windows.Forms.Label();
            this.panelForTools = new System.Windows.Forms.Panel();
            this.panelForInserting = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.buttonToPasteFrom = new System.Windows.Forms.ToolStripSplitButton();
            this.itemToPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToPasteFrom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.buttonForShapeFilling = new System.Windows.Forms.ToolStripSplitButton();
            this.itemWithoutFilling = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSolidColorFilling = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.buttonForOutLine = new System.Windows.Forms.ToolStripSplitButton();
            this.itemWithoutContour = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSolidColorContour = new System.Windows.Forms.ToolStripMenuItem();
            this.panelForPictureBox = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelForBackgroundColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForBackgroundColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.panelForMainColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForMainColor)).BeginInit();
            this.panelForWidth.SuspendLayout();
            this.panelForForm.SuspendLayout();
            this.panelForStatusBar.SuspendLayout();
            this.panelForTools.SuspendLayout();
            this.panelForInserting.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.panelForPictureBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonForBrush
            // 
            this.buttonForBrush.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonForBrush.Enabled = false;
            this.buttonForBrush.Image = ((System.Drawing.Image)(resources.GetObject("buttonForBrush.Image")));
            this.buttonForBrush.Location = new System.Drawing.Point(234, 35);
            this.buttonForBrush.Name = "buttonForBrush";
            this.buttonForBrush.Size = new System.Drawing.Size(38, 38);
            this.buttonForBrush.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buttonForBrush, "Кисть\r\nРисование с использованием кисти");
            this.buttonForBrush.UseVisualStyleBackColor = false;
            this.buttonForBrush.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Location = new System.Drawing.Point(5, 5);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(370, 113);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainPictureBox.TabIndex = 3;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPictureBoxPaint);
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPictureBoxMouseDown);
            this.mainPictureBox.MouseLeave += new System.EventHandler(this.MainPictureBoxMouseLeave);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPictureBoxMouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPictureBoxMouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonForFileMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MinimumSize = new System.Drawing.Size(0, 32);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 32);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // buttonForFileMenu
            // 
            this.buttonForFileMenu.AutoToolTip = true;
            this.buttonForFileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemToCreate,
            this.itemToOpen,
            this.itemToSave,
            this.itemToSaveAs});
            this.buttonForFileMenu.Image = ((System.Drawing.Image)(resources.GetObject("buttonForFileMenu.Image")));
            this.buttonForFileMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonForFileMenu.Name = "buttonForFileMenu";
            this.buttonForFileMenu.Size = new System.Drawing.Size(68, 28);
            this.buttonForFileMenu.ToolTipText = "Щелкните здесь, чтобы создать,\r\nоткрыть или сохранить изображение";
            // 
            // itemToCreate
            // 
            this.itemToCreate.Image = ((System.Drawing.Image)(resources.GetObject("itemToCreate.Image")));
            this.itemToCreate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemToCreate.Name = "itemToCreate";
            this.itemToCreate.Size = new System.Drawing.Size(171, 44);
            this.itemToCreate.Text = "Создать";
            this.itemToCreate.ToolTipText = "Создать (CTRL + N)\r\nСоздать новое изображение";
            this.itemToCreate.Click += new System.EventHandler(this.OnFileMenuClick);
            // 
            // itemToOpen
            // 
            this.itemToOpen.Image = ((System.Drawing.Image)(resources.GetObject("itemToOpen.Image")));
            this.itemToOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemToOpen.Name = "itemToOpen";
            this.itemToOpen.Size = new System.Drawing.Size(171, 44);
            this.itemToOpen.Text = "Открыть";
            this.itemToOpen.ToolTipText = "Открыть (CTRL + O)\r\nОткрыть существующее изображение";
            this.itemToOpen.Click += new System.EventHandler(this.OnFileMenuClick);
            // 
            // itemToSave
            // 
            this.itemToSave.Image = ((System.Drawing.Image)(resources.GetObject("itemToSave.Image")));
            this.itemToSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemToSave.Name = "itemToSave";
            this.itemToSave.Size = new System.Drawing.Size(171, 44);
            this.itemToSave.Text = "Сохранить";
            this.itemToSave.ToolTipText = "Сохранить (CTRL + S)\r\nСохранить текущее изображение";
            this.itemToSave.Click += new System.EventHandler(this.OnFileMenuClick);
            // 
            // itemToSaveAs
            // 
            this.itemToSaveAs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemImageFormatPNG,
            this.itemImageFormatJPEG,
            this.itemImageFormatBMP,
            this.itemImageFormatGIF});
            this.itemToSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("itemToSaveAs.Image")));
            this.itemToSaveAs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemToSaveAs.Name = "itemToSaveAs";
            this.itemToSaveAs.Size = new System.Drawing.Size(171, 44);
            this.itemToSaveAs.Text = "Сохранить как";
            this.itemToSaveAs.ToolTipText = "Сохранить как\r\nСохранить текущее изображение в новом файле";
            this.itemToSaveAs.Click += new System.EventHandler(this.OnFileMenuClick);
            // 
            // itemImageFormatPNG
            // 
            this.itemImageFormatPNG.Image = ((System.Drawing.Image)(resources.GetObject("itemImageFormatPNG.Image")));
            this.itemImageFormatPNG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemImageFormatPNG.Name = "itemImageFormatPNG";
            this.itemImageFormatPNG.Size = new System.Drawing.Size(253, 32);
            this.itemImageFormatPNG.Text = "Изображение в формате PNG";
            this.itemImageFormatPNG.Click += new System.EventHandler(this.OnFileMenuClick);
            // 
            // itemImageFormatJPEG
            // 
            this.itemImageFormatJPEG.Image = ((System.Drawing.Image)(resources.GetObject("itemImageFormatJPEG.Image")));
            this.itemImageFormatJPEG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemImageFormatJPEG.Name = "itemImageFormatJPEG";
            this.itemImageFormatJPEG.Size = new System.Drawing.Size(253, 32);
            this.itemImageFormatJPEG.Text = "Изображение в формате JPEG";
            this.itemImageFormatJPEG.Click += new System.EventHandler(this.OnFileMenuClick);
            // 
            // itemImageFormatBMP
            // 
            this.itemImageFormatBMP.Image = ((System.Drawing.Image)(resources.GetObject("itemImageFormatBMP.Image")));
            this.itemImageFormatBMP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemImageFormatBMP.Name = "itemImageFormatBMP";
            this.itemImageFormatBMP.Size = new System.Drawing.Size(253, 32);
            this.itemImageFormatBMP.Text = "Изображение в формате BMP";
            this.itemImageFormatBMP.Click += new System.EventHandler(this.OnFileMenuClick);
            // 
            // itemImageFormatGIF
            // 
            this.itemImageFormatGIF.Image = ((System.Drawing.Image)(resources.GetObject("itemImageFormatGIF.Image")));
            this.itemImageFormatGIF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemImageFormatGIF.Name = "itemImageFormatGIF";
            this.itemImageFormatGIF.Size = new System.Drawing.Size(253, 32);
            this.itemImageFormatGIF.Text = "Изображение в формате GIF";
            this.itemImageFormatGIF.Click += new System.EventHandler(this.OnFileMenuClick);
            // 
            // buttonForEraser
            // 
            this.buttonForEraser.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonForEraser.Image = ((System.Drawing.Image)(resources.GetObject("buttonForEraser.Image")));
            this.buttonForEraser.Location = new System.Drawing.Point(115, 30);
            this.buttonForEraser.Name = "buttonForEraser";
            this.buttonForEraser.Size = new System.Drawing.Size(28, 24);
            this.buttonForEraser.TabIndex = 6;
            this.toolTip1.SetToolTip(this.buttonForEraser, "Ластик\r\nСтирает изображение, заменяя его белым \r\nцветом или другим цветом, которы" +
        "й выбран \r\nвместо фонового");
            this.buttonForEraser.UseVisualStyleBackColor = false;
            this.buttonForEraser.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // buttonToPaste
            // 
            this.buttonToPaste.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonToPaste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonToPaste.Image = ((System.Drawing.Image)(resources.GetObject("buttonToPaste.Image")));
            this.buttonToPaste.Location = new System.Drawing.Point(2, 2);
            this.buttonToPaste.Margin = new System.Windows.Forms.Padding(2);
            this.buttonToPaste.Name = "buttonToPaste";
            this.buttonToPaste.Size = new System.Drawing.Size(81, 38);
            this.buttonToPaste.TabIndex = 7;
            this.toolTip1.SetToolTip(this.buttonToPaste, "Вставить (CTRL + V)\r\nВставка содержимого из буфера обмена");
            this.buttonToPaste.UseVisualStyleBackColor = false;
            this.buttonToPaste.Click += new System.EventHandler(this.OnClipboardCommandClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonForRotating});
            this.toolStrip1.Location = new System.Drawing.Point(103, 55);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(115, 26);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonForRotating
            // 
            this.buttonForRotating.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemToRotate90,
            this.itemToRotate270,
            this.itemToRotate180,
            this.itemToFlipVertical,
            this.itemToFlipHorizontal});
            this.buttonForRotating.Image = ((System.Drawing.Image)(resources.GetObject("buttonForRotating.Image")));
            this.buttonForRotating.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonForRotating.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonForRotating.Name = "buttonForRotating";
            this.buttonForRotating.Size = new System.Drawing.Size(103, 23);
            this.buttonForRotating.Text = "Повернуть";
            this.buttonForRotating.ToolTipText = "Повернуть или отразить\r\nПоворот или отражение изображения";
            // 
            // itemToRotate90
            // 
            this.itemToRotate90.Image = ((System.Drawing.Image)(resources.GetObject("itemToRotate90.Image")));
            this.itemToRotate90.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemToRotate90.Name = "itemToRotate90";
            this.itemToRotate90.Size = new System.Drawing.Size(264, 26);
            this.itemToRotate90.Text = "Повернуть на 90 градусов вправо";
            this.itemToRotate90.ToolTipText = "Поворот изображения\r\nна 90 градусов вправо";
            this.itemToRotate90.Click += new System.EventHandler(this.RotateClick);
            // 
            // itemToRotate270
            // 
            this.itemToRotate270.Image = ((System.Drawing.Image)(resources.GetObject("itemToRotate270.Image")));
            this.itemToRotate270.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemToRotate270.Name = "itemToRotate270";
            this.itemToRotate270.Size = new System.Drawing.Size(264, 26);
            this.itemToRotate270.Text = "Повернуть на 90 градусов влево";
            this.itemToRotate270.ToolTipText = "Поворот изображения\r\nна 90 градусов влево";
            this.itemToRotate270.Click += new System.EventHandler(this.RotateClick);
            // 
            // itemToRotate180
            // 
            this.itemToRotate180.Image = ((System.Drawing.Image)(resources.GetObject("itemToRotate180.Image")));
            this.itemToRotate180.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemToRotate180.Name = "itemToRotate180";
            this.itemToRotate180.Size = new System.Drawing.Size(264, 26);
            this.itemToRotate180.Text = "Повернуть на 180 градусов";
            this.itemToRotate180.ToolTipText = "Поворот изображения \r\nна 180 градусов";
            this.itemToRotate180.Click += new System.EventHandler(this.RotateClick);
            // 
            // itemToFlipVertical
            // 
            this.itemToFlipVertical.Image = ((System.Drawing.Image)(resources.GetObject("itemToFlipVertical.Image")));
            this.itemToFlipVertical.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemToFlipVertical.Name = "itemToFlipVertical";
            this.itemToFlipVertical.Size = new System.Drawing.Size(264, 26);
            this.itemToFlipVertical.Text = "Отразить по вертикали";
            this.itemToFlipVertical.ToolTipText = "Отражение изображения\r\nпо вертикали";
            this.itemToFlipVertical.Click += new System.EventHandler(this.RotateClick);
            // 
            // itemToFlipHorizontal
            // 
            this.itemToFlipHorizontal.Image = ((System.Drawing.Image)(resources.GetObject("itemToFlipHorizontal.Image")));
            this.itemToFlipHorizontal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemToFlipHorizontal.Name = "itemToFlipHorizontal";
            this.itemToFlipHorizontal.Size = new System.Drawing.Size(264, 26);
            this.itemToFlipHorizontal.Text = "Отразить по горизонтали";
            this.itemToFlipHorizontal.ToolTipText = "Отражение изображения \r\nпо горизонтали";
            this.itemToFlipHorizontal.Click += new System.EventHandler(this.RotateClick);
            // 
            // buttonForEllipse
            // 
            this.buttonForEllipse.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonForEllipse.Image = ((System.Drawing.Image)(resources.GetObject("buttonForEllipse.Image")));
            this.buttonForEllipse.Location = new System.Drawing.Point(339, 45);
            this.buttonForEllipse.Name = "buttonForEllipse";
            this.buttonForEllipse.Size = new System.Drawing.Size(25, 22);
            this.buttonForEllipse.TabIndex = 11;
            this.toolTip1.SetToolTip(this.buttonForEllipse, "Овал");
            this.buttonForEllipse.UseVisualStyleBackColor = false;
            this.buttonForEllipse.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // buttonForRectangle
            // 
            this.buttonForRectangle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonForRectangle.Image = ((System.Drawing.Image)(resources.GetObject("buttonForRectangle.Image")));
            this.buttonForRectangle.Location = new System.Drawing.Point(312, 45);
            this.buttonForRectangle.Name = "buttonForRectangle";
            this.buttonForRectangle.Size = new System.Drawing.Size(25, 22);
            this.buttonForRectangle.TabIndex = 12;
            this.toolTip1.SetToolTip(this.buttonForRectangle, "Прямоугольник");
            this.buttonForRectangle.UseVisualStyleBackColor = false;
            this.buttonForRectangle.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // buttonForLine
            // 
            this.buttonForLine.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonForLine.Image = ((System.Drawing.Image)(resources.GetObject("buttonForLine.Image")));
            this.buttonForLine.Location = new System.Drawing.Point(285, 45);
            this.buttonForLine.Name = "buttonForLine";
            this.buttonForLine.Size = new System.Drawing.Size(25, 22);
            this.buttonForLine.TabIndex = 13;
            this.toolTip1.SetToolTip(this.buttonForLine, "Линия");
            this.buttonForLine.UseVisualStyleBackColor = false;
            this.buttonForLine.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // buttonForColorFilling
            // 
            this.buttonForColorFilling.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonForColorFilling.Image = ((System.Drawing.Image)(resources.GetObject("buttonForColorFilling.Image")));
            this.buttonForColorFilling.Location = new System.Drawing.Point(145, 30);
            this.buttonForColorFilling.Margin = new System.Windows.Forms.Padding(0);
            this.buttonForColorFilling.Name = "buttonForColorFilling";
            this.buttonForColorFilling.Size = new System.Drawing.Size(28, 24);
            this.buttonForColorFilling.TabIndex = 14;
            this.toolTip1.SetToolTip(this.buttonForColorFilling, "Заливка области\r\nЩелкните область холста, чтобы\r\nзаполнить ее основным цветом");
            this.buttonForColorFilling.UseVisualStyleBackColor = false;
            this.buttonForColorFilling.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // panelForBackgroundColor
            // 
            this.panelForBackgroundColor.Controls.Add(this.labelForBackgroundColor);
            this.panelForBackgroundColor.Controls.Add(this.pictureBoxForBackgroundColor);
            this.panelForBackgroundColor.Location = new System.Drawing.Point(697, 25);
            this.panelForBackgroundColor.Name = "panelForBackgroundColor";
            this.panelForBackgroundColor.Padding = new System.Windows.Forms.Padding(5);
            this.panelForBackgroundColor.Size = new System.Drawing.Size(53, 57);
            this.panelForBackgroundColor.TabIndex = 18;
            this.toolTip1.SetToolTip(this.panelForBackgroundColor, "Цвет 2 (цвет фона)\r\nЩелкните здесь и выберите цвет на\r\nцветовой палитре. Этот цве" +
        "т используется\r\nдля ластика, а также для заливки фигур");
            this.panelForBackgroundColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelForBackgroundColorMouseClick);
            // 
            // labelForBackgroundColor
            // 
            this.labelForBackgroundColor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelForBackgroundColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelForBackgroundColor.Location = new System.Drawing.Point(5, 30);
            this.labelForBackgroundColor.Name = "labelForBackgroundColor";
            this.labelForBackgroundColor.Size = new System.Drawing.Size(43, 22);
            this.labelForBackgroundColor.TabIndex = 1;
            this.labelForBackgroundColor.Text = "Цвет 2";
            this.labelForBackgroundColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labelForBackgroundColor, "Цвет 2 (цвет фона)\r\nЩелкните здесь и выберите цвет на\r\nцветовой палитре. Этот цве" +
        "т используется\r\nдля ластика, а также для заливки фигур");
            this.labelForBackgroundColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelForBackgroundColorMouseClick);
            // 
            // pictureBoxForBackgroundColor
            // 
            this.pictureBoxForBackgroundColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxForBackgroundColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxForBackgroundColor.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxForBackgroundColor.Name = "pictureBoxForBackgroundColor";
            this.pictureBoxForBackgroundColor.Size = new System.Drawing.Size(43, 24);
            this.pictureBoxForBackgroundColor.TabIndex = 0;
            this.pictureBoxForBackgroundColor.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxForBackgroundColor, "Цвет 2 (цвет фона)\r\nЩелкните здесь и выберите цвет на\r\nцветовой палитре. Этот цве" +
        "т используется\r\nдля ластика, а также для заливки фигур");
            this.pictureBoxForBackgroundColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelForBackgroundColorMouseClick);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.numericUpDown.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown.Location = new System.Drawing.Point(93, 2);
            this.numericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(38, 22);
            this.numericUpDown.TabIndex = 15;
            this.numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.numericUpDown, "Толщина\r\nВыбор ширины для заданного\r\nинструмента");
            this.numericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDownValueChanged);
            this.numericUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumericUpDownKeyUp);
            // 
            // panelForMainColor
            // 
            this.panelForMainColor.Controls.Add(this.labelForMainColor);
            this.panelForMainColor.Controls.Add(this.pictureBoxForMainColor);
            this.panelForMainColor.Location = new System.Drawing.Point(642, 25);
            this.panelForMainColor.Name = "panelForMainColor";
            this.panelForMainColor.Padding = new System.Windows.Forms.Padding(5);
            this.panelForMainColor.Size = new System.Drawing.Size(53, 57);
            this.panelForMainColor.TabIndex = 17;
            this.toolTip1.SetToolTip(this.panelForMainColor, "Цвет 1 (основной цвет)\r\nЩелкните здесь и выберите цвет на\r\nцветовой палитре. Этот" +
        " цвет используется\r\nдля заливки области, кисти, а также для\r\nконтуров фигур");
            this.panelForMainColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelForMainColorMouseClick);
            // 
            // labelForMainColor
            // 
            this.labelForMainColor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelForMainColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelForMainColor.Location = new System.Drawing.Point(5, 30);
            this.labelForMainColor.Name = "labelForMainColor";
            this.labelForMainColor.Size = new System.Drawing.Size(43, 22);
            this.labelForMainColor.TabIndex = 0;
            this.labelForMainColor.Text = "Цвет 1";
            this.labelForMainColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.labelForMainColor, "Цвет 1 (основной цвет)\r\nЩелкните здесь и выберите цвет на\r\nцветовой палитре. Этот" +
        " цвет используется\r\nдля заливки области, кисти, а также для\r\nконтуров фигур");
            this.labelForMainColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelForMainColorMouseClick);
            // 
            // pictureBoxForMainColor
            // 
            this.pictureBoxForMainColor.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureBoxForMainColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxForMainColor.Location = new System.Drawing.Point(5, 5);
            this.pictureBoxForMainColor.Name = "pictureBoxForMainColor";
            this.pictureBoxForMainColor.Size = new System.Drawing.Size(43, 24);
            this.pictureBoxForMainColor.TabIndex = 17;
            this.pictureBoxForMainColor.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxForMainColor, "Цвет 1 (основной цвет)\r\nЩелкните здесь и выберите цвет на\r\nцветовой палитре. Этот" +
        " цвет используется\r\nдля заливки области, кисти, а также для\r\nконтуров фигур");
            this.pictureBoxForMainColor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelForMainColorMouseClick);
            // 
            // buttonForPipette
            // 
            this.buttonForPipette.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonForPipette.Image = ((System.Drawing.Image)(resources.GetObject("buttonForPipette.Image")));
            this.buttonForPipette.Location = new System.Drawing.Point(175, 30);
            this.buttonForPipette.Name = "buttonForPipette";
            this.buttonForPipette.Size = new System.Drawing.Size(28, 24);
            this.buttonForPipette.TabIndex = 21;
            this.toolTip1.SetToolTip(this.buttonForPipette, "Пипетка\r\nЛевой кнопкой берёт основной\r\nцвет, правой - фоновый");
            this.buttonForPipette.UseVisualStyleBackColor = false;
            this.buttonForPipette.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PipetteMouseDown);
            // 
            // buttonForUndo
            // 
            this.buttonForUndo.Image = ((System.Drawing.Image)(resources.GetObject("buttonForUndo.Image")));
            this.buttonForUndo.Location = new System.Drawing.Point(74, 3);
            this.buttonForUndo.Name = "buttonForUndo";
            this.buttonForUndo.Size = new System.Drawing.Size(29, 26);
            this.buttonForUndo.TabIndex = 23;
            this.toolTip1.SetToolTip(this.buttonForUndo, "Отменить (CTRL + Z)\r\nОтмена последнего действия");
            this.buttonForUndo.UseVisualStyleBackColor = true;
            this.buttonForUndo.Click += new System.EventHandler(this.OnUndoClick);
            // 
            // buttonForRedo
            // 
            this.buttonForRedo.Image = ((System.Drawing.Image)(resources.GetObject("buttonForRedo.Image")));
            this.buttonForRedo.Location = new System.Drawing.Point(107, 3);
            this.buttonForRedo.Name = "buttonForRedo";
            this.buttonForRedo.Size = new System.Drawing.Size(29, 26);
            this.buttonForRedo.TabIndex = 23;
            this.toolTip1.SetToolTip(this.buttonForRedo, "Вернуть (CTRL + Y)\r\nПовтор последнего действия");
            this.buttonForRedo.UseVisualStyleBackColor = true;
            this.buttonForRedo.Click += new System.EventHandler(this.OnRedoClick);
            // 
            // panelForWidth
            // 
            this.panelForWidth.Controls.Add(this.numericUpDown);
            this.panelForWidth.Controls.Add(this.labelForWidth);
            this.panelForWidth.Location = new System.Drawing.Point(497, 43);
            this.panelForWidth.Name = "panelForWidth";
            this.panelForWidth.Padding = new System.Windows.Forms.Padding(2);
            this.panelForWidth.Size = new System.Drawing.Size(133, 24);
            this.panelForWidth.TabIndex = 24;
            this.toolTip1.SetToolTip(this.panelForWidth, "Толщина\r\nВыбор ширины для заданного\r\nинструмента");
            // 
            // labelForWidth
            // 
            this.labelForWidth.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelForWidth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelForWidth.Image = ((System.Drawing.Image)(resources.GetObject("labelForWidth.Image")));
            this.labelForWidth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelForWidth.Location = new System.Drawing.Point(2, 2);
            this.labelForWidth.Name = "labelForWidth";
            this.labelForWidth.Size = new System.Drawing.Size(91, 20);
            this.labelForWidth.TabIndex = 17;
            this.labelForWidth.Text = "Толщина:";
            this.labelForWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.labelForWidth, "Толщина\r\nВыбор ширины для заданного\r\nинструмента");
            // 
            // buttonForSelection
            // 
            this.buttonForSelection.Image = ((System.Drawing.Image)(resources.GetObject("buttonForSelection.Image")));
            this.buttonForSelection.Location = new System.Drawing.Point(773, 25);
            this.buttonForSelection.Name = "buttonForSelection";
            this.buttonForSelection.Size = new System.Drawing.Size(43, 40);
            this.buttonForSelection.TabIndex = 24;
            this.toolTip1.SetToolTip(this.buttonForSelection, "Выделение\r\nВыделение фрагмента изображения");
            this.buttonForSelection.UseVisualStyleBackColor = false;
            this.buttonForSelection.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // panelForForm
            // 
            this.panelForForm.AutoScroll = true;
            this.panelForForm.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelForForm.Controls.Add(this.panelForStatusBar);
            this.panelForForm.Controls.Add(this.panelForTools);
            this.panelForForm.Controls.Add(this.panelForPictureBox);
            this.panelForForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForForm.Location = new System.Drawing.Point(0, 32);
            this.panelForForm.Name = "panelForForm";
            this.panelForForm.Size = new System.Drawing.Size(903, 261);
            this.panelForForm.TabIndex = 15;
            // 
            // panelForStatusBar
            // 
            this.panelForStatusBar.BackColor = System.Drawing.SystemColors.Control;
            this.panelForStatusBar.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelForStatusBar.ColumnCount = 3;
            this.panelForStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.panelForStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.panelForStatusBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelForStatusBar.Controls.Add(this.labelForPictureBoxSize, 1, 0);
            this.panelForStatusBar.Controls.Add(this.labelForCursorLocation, 0, 0);
            this.panelForStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelForStatusBar.Location = new System.Drawing.Point(0, 235);
            this.panelForStatusBar.Name = "panelForStatusBar";
            this.panelForStatusBar.RowCount = 1;
            this.panelForStatusBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelForStatusBar.Size = new System.Drawing.Size(903, 26);
            this.panelForStatusBar.TabIndex = 24;
            // 
            // labelForPictureBoxSize
            // 
            this.labelForPictureBoxSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelForPictureBoxSize.Image = ((System.Drawing.Image)(resources.GetObject("labelForPictureBoxSize.Image")));
            this.labelForPictureBoxSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelForPictureBoxSize.Location = new System.Drawing.Point(165, 1);
            this.labelForPictureBoxSize.Name = "labelForPictureBoxSize";
            this.labelForPictureBoxSize.Size = new System.Drawing.Size(154, 24);
            this.labelForPictureBoxSize.TabIndex = 1;
            this.labelForPictureBoxSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelForCursorLocation
            // 
            this.labelForCursorLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelForCursorLocation.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelForCursorLocation.Image = ((System.Drawing.Image)(resources.GetObject("labelForCursorLocation.Image")));
            this.labelForCursorLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelForCursorLocation.Location = new System.Drawing.Point(4, 1);
            this.labelForCursorLocation.Name = "labelForCursorLocation";
            this.labelForCursorLocation.Size = new System.Drawing.Size(154, 24);
            this.labelForCursorLocation.TabIndex = 0;
            this.labelForCursorLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelForTools
            // 
            this.panelForTools.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelForTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForTools.Controls.Add(this.buttonForSelection);
            this.panelForTools.Controls.Add(this.panelForWidth);
            this.panelForTools.Controls.Add(this.panelForInserting);
            this.panelForTools.Controls.Add(this.toolStrip1);
            this.panelForTools.Controls.Add(this.panelForBackgroundColor);
            this.panelForTools.Controls.Add(this.toolStrip4);
            this.panelForTools.Controls.Add(this.buttonForColorFilling);
            this.panelForTools.Controls.Add(this.panelForMainColor);
            this.panelForTools.Controls.Add(this.toolStrip3);
            this.panelForTools.Controls.Add(this.buttonForPipette);
            this.panelForTools.Controls.Add(this.buttonForEraser);
            this.panelForTools.Controls.Add(this.buttonForBrush);
            this.panelForTools.Controls.Add(this.buttonForLine);
            this.panelForTools.Controls.Add(this.buttonForEllipse);
            this.panelForTools.Controls.Add(this.buttonForRectangle);
            this.panelForTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelForTools.Location = new System.Drawing.Point(0, 0);
            this.panelForTools.Name = "panelForTools";
            this.panelForTools.Size = new System.Drawing.Size(903, 105);
            this.panelForTools.TabIndex = 23;
            // 
            // panelForInserting
            // 
            this.panelForInserting.ColumnCount = 1;
            this.panelForInserting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelForInserting.Controls.Add(this.toolStrip2, 0, 1);
            this.panelForInserting.Controls.Add(this.buttonToPaste, 0, 0);
            this.panelForInserting.Location = new System.Drawing.Point(7, 8);
            this.panelForInserting.Name = "panelForInserting";
            this.panelForInserting.RowCount = 2;
            this.panelForInserting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.panelForInserting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.panelForInserting.Size = new System.Drawing.Size(85, 74);
            this.panelForInserting.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonToPasteFrom});
            this.toolStrip2.Location = new System.Drawing.Point(0, 42);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(85, 32);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // buttonToPasteFrom
            // 
            this.buttonToPasteFrom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonToPasteFrom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemToPaste,
            this.itemToPasteFrom});
            this.buttonToPasteFrom.Image = ((System.Drawing.Image)(resources.GetObject("buttonToPasteFrom.Image")));
            this.buttonToPasteFrom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonToPasteFrom.Name = "buttonToPasteFrom";
            this.buttonToPasteFrom.Size = new System.Drawing.Size(71, 29);
            this.buttonToPasteFrom.Text = "Вставить";
            this.buttonToPasteFrom.ToolTipText = "Вставить (CTRL + V)\r\nЩелкните здесь, чтобы получить доступ к\r\nдополнительным пара" +
    "метрам, например, \r\nфункциям вставки содержимого из\r\nбуфера обмена или файла";
            // 
            // itemToPaste
            // 
            this.itemToPaste.Image = ((System.Drawing.Image)(resources.GetObject("itemToPaste.Image")));
            this.itemToPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemToPaste.Name = "itemToPaste";
            this.itemToPaste.Size = new System.Drawing.Size(145, 30);
            this.itemToPaste.Text = "Вставить";
            this.itemToPaste.ToolTipText = "Вставить (CTRL + V)\r\nВставка содержимого из буфера обмена";
            this.itemToPaste.Click += new System.EventHandler(this.OnClipboardCommandClick);
            // 
            // itemToPasteFrom
            // 
            this.itemToPasteFrom.Image = ((System.Drawing.Image)(resources.GetObject("itemToPasteFrom.Image")));
            this.itemToPasteFrom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemToPasteFrom.Name = "itemToPasteFrom";
            this.itemToPasteFrom.Size = new System.Drawing.Size(145, 30);
            this.itemToPasteFrom.Text = "Вставить из";
            this.itemToPasteFrom.ToolTipText = "Открытие диалогового окна \"Вставить из\"\r\nи выбор файла для вставки";
            this.itemToPasteFrom.Click += new System.EventHandler(this.OnClipboardCommandClick);
            // 
            // toolStrip4
            // 
            this.toolStrip4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonForShapeFilling});
            this.toolStrip4.Location = new System.Drawing.Point(381, 55);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(100, 26);
            this.toolStrip4.TabIndex = 20;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // buttonForShapeFilling
            // 
            this.buttonForShapeFilling.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemWithoutFilling,
            this.itemSolidColorFilling});
            this.buttonForShapeFilling.Image = ((System.Drawing.Image)(resources.GetObject("buttonForShapeFilling.Image")));
            this.buttonForShapeFilling.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonForShapeFilling.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonForShapeFilling.Name = "buttonForShapeFilling";
            this.buttonForShapeFilling.Size = new System.Drawing.Size(88, 23);
            this.buttonForShapeFilling.Text = "Заливка";
            this.buttonForShapeFilling.ToolTipText = "Заливка фигуры\r\nВыбор метода заливки фигуры";
            // 
            // itemWithoutFilling
            // 
            this.itemWithoutFilling.Image = ((System.Drawing.Image)(resources.GetObject("itemWithoutFilling.Image")));
            this.itemWithoutFilling.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemWithoutFilling.Name = "itemWithoutFilling";
            this.itemWithoutFilling.Size = new System.Drawing.Size(166, 26);
            this.itemWithoutFilling.Text = "Без заливки";
            this.itemWithoutFilling.Click += new System.EventHandler(this.OnItemForShapeFillingClick);
            // 
            // itemSolidColorFilling
            // 
            this.itemSolidColorFilling.Image = ((System.Drawing.Image)(resources.GetObject("itemSolidColorFilling.Image")));
            this.itemSolidColorFilling.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemSolidColorFilling.Name = "itemSolidColorFilling";
            this.itemSolidColorFilling.Size = new System.Drawing.Size(166, 26);
            this.itemSolidColorFilling.Text = "Сплошной цвет";
            this.itemSolidColorFilling.Click += new System.EventHandler(this.OnItemForShapeFillingClick);
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonForOutLine});
            this.toolStrip3.Location = new System.Drawing.Point(381, 28);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(94, 26);
            this.toolStrip3.TabIndex = 19;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // buttonForOutLine
            // 
            this.buttonForOutLine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemWithoutContour,
            this.itemSolidColorContour});
            this.buttonForOutLine.Image = ((System.Drawing.Image)(resources.GetObject("buttonForOutLine.Image")));
            this.buttonForOutLine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonForOutLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonForOutLine.Name = "buttonForOutLine";
            this.buttonForOutLine.Size = new System.Drawing.Size(82, 23);
            this.buttonForOutLine.Text = "Контур";
            this.buttonForOutLine.ToolTipText = "Контур фигуры\r\nВыбор метода рисования\r\nконтура фигуры";
            // 
            // itemWithoutContour
            // 
            this.itemWithoutContour.Image = ((System.Drawing.Image)(resources.GetObject("itemWithoutContour.Image")));
            this.itemWithoutContour.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemWithoutContour.Name = "itemWithoutContour";
            this.itemWithoutContour.Size = new System.Drawing.Size(166, 26);
            this.itemWithoutContour.Text = "Без контура";
            this.itemWithoutContour.Click += new System.EventHandler(this.OnItemForOutLineClick);
            // 
            // itemSolidColorContour
            // 
            this.itemSolidColorContour.Image = ((System.Drawing.Image)(resources.GetObject("itemSolidColorContour.Image")));
            this.itemSolidColorContour.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.itemSolidColorContour.Name = "itemSolidColorContour";
            this.itemSolidColorContour.Size = new System.Drawing.Size(166, 26);
            this.itemSolidColorContour.Text = "Сплошной цвет";
            this.itemSolidColorContour.Click += new System.EventHandler(this.OnItemForOutLineClick);
            // 
            // panelForPictureBox
            // 
            this.panelForPictureBox.Controls.Add(this.mainPictureBox);
            this.panelForPictureBox.Location = new System.Drawing.Point(2, 106);
            this.panelForPictureBox.MinimumSize = new System.Drawing.Size(11, 11);
            this.panelForPictureBox.Name = "panelForPictureBox";
            this.panelForPictureBox.Padding = new System.Windows.Forms.Padding(5);
            this.panelForPictureBox.Size = new System.Drawing.Size(380, 123);
            this.panelForPictureBox.TabIndex = 17;
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 293);
            this.Controls.Add(this.buttonForRedo);
            this.Controls.Add(this.buttonForUndo);
            this.Controls.Add(this.panelForForm);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Paint";
            this.Text = "Paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PaintFormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PaintKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelForBackgroundColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForBackgroundColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.panelForMainColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForMainColor)).EndInit();
            this.panelForWidth.ResumeLayout(false);
            this.panelForForm.ResumeLayout(false);
            this.panelForStatusBar.ResumeLayout(false);
            this.panelForTools.ResumeLayout(false);
            this.panelForTools.PerformLayout();
            this.panelForInserting.ResumeLayout(false);
            this.panelForInserting.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panelForPictureBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonForBrush;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem buttonForFileMenu;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Button buttonForEraser;
        private System.Windows.Forms.Button buttonToPaste;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton buttonForRotating;
        private System.Windows.Forms.ToolStripMenuItem itemToRotate90;
        private System.Windows.Forms.ToolStripMenuItem itemToRotate270;
        private System.Windows.Forms.ToolStripMenuItem itemToRotate180;
        private System.Windows.Forms.ToolStripMenuItem itemToFlipVertical;
        private System.Windows.Forms.ToolStripMenuItem itemToFlipHorizontal;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonForEllipse;
        private System.Windows.Forms.Button buttonForRectangle;
        private System.Windows.Forms.Button buttonForLine;
        private System.Windows.Forms.Button buttonForColorFilling;
        private System.Windows.Forms.Panel panelForForm;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.PictureBox pictureBoxForMainColor;
        private System.Windows.Forms.Panel panelForMainColor;
        private System.Windows.Forms.Panel panelForBackgroundColor;
        private System.Windows.Forms.Label labelForBackgroundColor;
        private System.Windows.Forms.PictureBox pictureBoxForBackgroundColor;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripSplitButton buttonForOutLine;
        private System.Windows.Forms.ToolStripMenuItem itemWithoutContour;
        private System.Windows.Forms.ToolStripMenuItem itemSolidColorContour;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripSplitButton buttonForShapeFilling;
        private System.Windows.Forms.ToolStripMenuItem itemWithoutFilling;
        private System.Windows.Forms.ToolStripMenuItem itemSolidColorFilling;
        private System.Windows.Forms.Button buttonForPipette;
        private System.Windows.Forms.Button buttonForUndo;
        private System.Windows.Forms.Button buttonForRedo;
        private System.Windows.Forms.Panel panelForTools;
        private System.Windows.Forms.Label labelForCursorLocation;
        private System.Windows.Forms.Label labelForPictureBoxSize;
        private System.Windows.Forms.TableLayoutPanel panelForStatusBar;
        private System.Windows.Forms.TableLayoutPanel panelForInserting;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSplitButton buttonToPasteFrom;
        private System.Windows.Forms.ToolStripMenuItem itemToPaste;
        private System.Windows.Forms.ToolStripMenuItem itemToPasteFrom;
        private System.Windows.Forms.Panel panelForPictureBox;
        private System.Windows.Forms.Panel panelForWidth;
        private System.Windows.Forms.ToolStripMenuItem itemToCreate;
        private System.Windows.Forms.ToolStripMenuItem itemToOpen;
        private System.Windows.Forms.ToolStripMenuItem itemToSave;
        private System.Windows.Forms.ToolStripMenuItem itemToSaveAs;
        private System.Windows.Forms.ToolStripMenuItem itemImageFormatPNG;
        private System.Windows.Forms.ToolStripMenuItem itemImageFormatJPEG;
        private System.Windows.Forms.ToolStripMenuItem itemImageFormatBMP;
        private System.Windows.Forms.ToolStripMenuItem itemImageFormatGIF;
        private System.Windows.Forms.Label labelForMainColor;
        private System.Windows.Forms.Label labelForWidth;
        private System.Windows.Forms.Button buttonForSelection;
    }
}

