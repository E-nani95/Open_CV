namespace Kiosk_Prototype
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Kiosk_Prototype.Models.Product product1 = new Kiosk_Prototype.Models.Product();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Kiosk_Prototype.Models.Product product2 = new Kiosk_Prototype.Models.Product();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.productList1 = new Kiosk_Prototype.Components.Products.ProductList();
            this.roundedButton2 = new Kiosk_Prototype.Components.RoundedButton();
            this.roundedButton1 = new Kiosk_Prototype.Components.RoundedButton();
            this.orderSummaryControl1 = new Kiosk_Prototype.Components.OrderSummaryControl();
            this.picklist = new Kiosk_Prototype.Components.Picks.PickList();
            this.productCard1 = new Kiosk_Prototype.Components.Products.ProductCard();
            this.roundedPanel1 = new Kiosk_Prototype.Components.RoundedPanel();
            this.headerControllor1 = new Kiosk_Prototype.Components.HeaderControllor();
            this.countDownTimer1 = new Kiosk_Prototype.Components.CountDownTimer(this.components);
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(362, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(379, 28);
            this.textBox1.TabIndex = 5;
            // 
            // productList1
            // 
            this.productList1.AutoScroll = true;
            this.productList1.BackColor = System.Drawing.Color.Transparent;
            this.productList1.BorderColor = System.Drawing.Color.Black;
            this.productList1.BorderWidth = 2;
            product1.ID = 1;
            product1.Image = ((System.Drawing.Image)(resources.GetObject("product1.Image")));
            product1.Price = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            product1.Title = "11";
            product2.ID = 2;
            product2.Image = ((System.Drawing.Image)(resources.GetObject("product2.Image")));
            product2.Price = new decimal(new int[] {
            222,
            0,
            0,
            0});
            product2.Title = "1113";
            this.productList1.Items.Add(product1);
            this.productList1.Items.Add(product2);
            this.productList1.Location = new System.Drawing.Point(31, 133);
            this.productList1.Name = "productList1";
            this.productList1.Size = new System.Drawing.Size(779, 454);
            this.productList1.TabIndex = 8;
            this.productList1.ItemClicked += new System.EventHandler<Kiosk_Prototype.Models.Product>(this.productList1_ItemClicked_1);
            // 
            // roundedButton2
            // 
            this.roundedButton2.BackColor = System.Drawing.Color.Salmon;
            this.roundedButton2.BorderColor = System.Drawing.Color.Salmon;
            this.roundedButton2.BorderWidth = 2;
            this.roundedButton2.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.roundedButton2.ForeColor = System.Drawing.Color.White;
            this.roundedButton2.Location = new System.Drawing.Point(864, 726);
            this.roundedButton2.Margin = new System.Windows.Forms.Padding(0);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(161, 133);
            this.roundedButton2.TabIndex = 7;
            this.roundedButton2.Text = "lblText";
            this.roundedButton2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.DodgerBlue;
            this.roundedButton1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.roundedButton1.BorderWidth = 2;
            this.roundedButton1.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.roundedButton1.ForeColor = System.Drawing.Color.White;
            this.roundedButton1.Location = new System.Drawing.Point(1032, 726);
            this.roundedButton1.Margin = new System.Windows.Forms.Padding(0);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(161, 133);
            this.roundedButton1.TabIndex = 7;
            this.roundedButton1.Text = "lblText";
            this.roundedButton1.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // orderSummaryControl1
            // 
            this.orderSummaryControl1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.orderSummaryControl1.BorderWidth = 1;
            this.orderSummaryControl1.Count = 0;
            this.orderSummaryControl1.Location = new System.Drawing.Point(844, 584);
            this.orderSummaryControl1.Name = "orderSummaryControl1";
            this.orderSummaryControl1.Size = new System.Drawing.Size(377, 150);
            this.orderSummaryControl1.TabIndex = 6;
            this.orderSummaryControl1.TotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // picklist
            // 
            this.picklist.BorderColor = System.Drawing.Color.Salmon;
            this.picklist.BorderWidth = 1;
            this.picklist.Location = new System.Drawing.Point(31, 584);
            this.picklist.Name = "picklist";
            this.picklist.Size = new System.Drawing.Size(779, 266);
            this.picklist.TabIndex = 4;
            this.picklist.ItemValueChanged += new Kiosk_Prototype.Components.Picks.ItemValueChangedHandler(this.picklist_ItemValueChanged);
            // 
            // productCard1
            // 
            this.productCard1.BackColor = System.Drawing.Color.Transparent;
            this.productCard1.ID = 0;
            this.productCard1.Image = ((System.Drawing.Image)(resources.GetObject("productCard1.Image")));
            this.productCard1.Location = new System.Drawing.Point(1032, 0);
            this.productCard1.Name = "productCard1";
            this.productCard1.Price = new decimal(new int[] {
            3333,
            0,
            0,
            0});
            this.productCard1.Size = new System.Drawing.Size(156, 145);
            this.productCard1.TabIndex = 2;
            this.productCard1.Title = "apple";
            this.productCard1.Clicked += new System.EventHandler<Kiosk_Prototype.Components.Products.IPorductCard>(this.productCard1_Clicked);
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BorderBackgroundColor = System.Drawing.Color.Silver;
            this.roundedPanel1.BorderColor = System.Drawing.Color.RosyBrown;
            this.roundedPanel1.BorderRadius = 50;
            this.roundedPanel1.Location = new System.Drawing.Point(747, 41);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(137, 69);
            this.roundedPanel1.TabIndex = 1;
            // 
            // headerControllor1
            // 
            this.headerControllor1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerControllor1.HeaderDescriptionFunc = "HeaderDescription";
            this.headerControllor1.HeaderTitleFunc = "HeaderTitle";
            this.headerControllor1.Location = new System.Drawing.Point(0, 0);
            this.headerControllor1.Name = "headerControllor1";
            this.headerControllor1.Size = new System.Drawing.Size(1243, 167);
            this.headerControllor1.TabIndex = 0;
            // 
            // countDownTimer1
            // 
            this.countDownTimer1.WaitSeconds = 10;
            this.countDownTimer1.Tick += new Kiosk_Prototype.Components.CountDownTickEventHandler(this.countDownTimer1_Tick_1);
            this.countDownTimer1.CountDownEnded += new System.Action(this.countDownTimer1_CountDownEnded);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1243, 871);
            this.Controls.Add(this.productList1);
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.orderSummaryControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.picklist);
            this.Controls.Add(this.productCard1);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.headerControllor1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.HeaderControllor headerControllor1;
        private Components.RoundedPanel roundedPanel1;
        private Components.Products.ProductCard productCard1;
        private Components.Picks.PickList picklist;
        private System.Windows.Forms.TextBox textBox1;
        private Components.OrderSummaryControl orderSummaryControl1;
        private Components.RoundedButton roundedButton1;
        private Components.RoundedButton roundedButton2;
        private Components.CountDownTimer countDownTimer1;
        private Components.Products.ProductList productList1;
    }
}

