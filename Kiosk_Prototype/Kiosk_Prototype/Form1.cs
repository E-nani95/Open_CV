using Kiosk_Prototype.Components.Picks;
using Kiosk_Prototype.Dialogs;
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

namespace Kiosk_Prototype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //ProductCard 클릭이벤트 반응 테스트용
        private void productCard1_Clicked(object sender, Components.Products.IPorductCard e)
        {
            // 클릭하면 메시지 박스나오는 이벤트
            MessageBox.Show($"{e.Title}, {e.Price}");
        }


        private void productList1_ItemClicked_1(object sender, Models.Product e)
        {
            picklist.AddItem(e);
        }

        private void picklist_ItemValueChanged(List<PickItem> pickItems)
        {
            //Timer 시작 혹은 중지
            if (pickItems.Any())
            {
                countDownTimer1.Start();
            }
            else 
            {
                countDownTimer1.Stop();
            }

                //Summary




                //Test코드
                //var itmeInfoTexts = pickItems.Select(item => $"Title: {item.Title}, Count: {item.Count}, Price: {item.DefaultPrice * item.Count}");

                //textBox1.Text = String.Join("\r\n", itmeInfoTexts);
                int totalCount = pickItems.Sum(item => item.Count);
            decimal totalPrice = pickItems.Sum(item => item.Count * item.DefaultPrice);

            orderSummaryControl1.Count = totalCount;  
            orderSummaryControl1.TotalPrice = totalPrice;
        }


        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogBox.ShowReceiptDialog(this, picklist.GetItems());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            picklist.Clear();
        }


        private void countDownTimer1_CountDownEnded()
        {
            picklist.Clear();
        }



        private void countDownTimer1_Tick_1(int remainingSeconds)
        {
            Debug.Print(remainingSeconds.ToString());
        }

        private void picklist_ItemValueChanged(List<T> pickItems)
        {

        }
    }
}
