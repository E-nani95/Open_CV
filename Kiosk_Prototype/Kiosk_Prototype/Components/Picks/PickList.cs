using Kiosk_Prototype.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_Prototype.Components.Picks
{
    //Pick이벤트의 아이템들의 상태가 바뀌면 그 이벤트를 호출해주는 코드 작성
    public delegate void ItemValueChangedHandler(List<PickItem> pickItems);
    [DefaultEvent("ItemValueChanged")]
    public partial class PickList : UserControl
    {
        private List<PickItem> _pickItems = new List<PickItem>();
        public PickList()
        {
            InitializeComponent();
        }

        private void RaiseItemValueChanged() => ItemValueChanged?.Invoke(_pickItems);

        public event ItemValueChangedHandler ItemValueChanged;

        // ProductList & PickList Border정보 수정
        public Color BorderColor { get => roundedPanel1.BorderColor; set => roundedPanel1.BorderColor = value; }
        public int BorderWidth { get => roundedPanel1.BorderWitdh; set => roundedPanel1.BorderWitdh = value; }

        public void AddItem(Product product) 
        {
            PickItem pickitem;
            // PickItem이 이미 추가가 되어 있는 경우
            //FirstOrDefault 이 배열에서 첫번쨰 꺼만 뽑아냄 -> 없으면 null 반환
            //item => item.ID == product.ID -> 고른 아이템의 ID와 product안에 ID가 같으면 이미 있다는 뜻
            pickitem = _pickItems.FirstOrDefault(item => item.ID == product.ID);
            
            //null이 아닌라는건 이미 picklist에 고른 상품이 존재한다는걸의미
            if (pickitem != null) 
            {
                //Count가 더해지면 자동으로 밑에 Change나 Delete이벤트가 작동해서 RaiseItemValueChanged()는 넣지 않음 
                pickitem.Count++;
                return;
            }

            //PickItem이 존재하지 않는 경우
            pickitem = new PickItem
            {
                ID = product.ID,
                Title = product.Title,
                DefaultPrice=product.Price,
                Image = product.Image,
                Count=1,
            };

            _pickItems.Add(pickitem);
            flpnl.Controls.Add(pickitem);

            //이벤트 추가 - PickItem에 있던거
            pickitem.DeleteClicked += PickItem_DeleteClicked;
            pickitem.CountChanged += PickItem_CountChanged;

            RaiseItemValueChanged();
        }

        private void PickItem_CountChanged(object sender, EventArgs e)
        {
            // 따로 구현보다 Pick이벤트의 아이템들의 상태가 바뀌면 그 이벤트를 호출해주는 코드 작성
            RaiseItemValueChanged();
        }

        // Deleteclicked를 하면 sender를 통해 이함수로 넘어옴
        private void PickItem_DeleteClicked(object sender, EventArgs e)
        {
            // Pick아이템 타입으로 sender를 언박싱
            PickItem pickitem = (PickItem)sender;
            _pickItems.Remove(pickitem);
            flpnl.Controls.Remove(pickitem);

            RaiseItemValueChanged();
        }

        internal List<PickItem> GetItems()
        {
            return _pickItems;
        }

        internal void Clear()
        {
            _pickItems.Clear();
            flpnl.Controls.Clear();

            RaiseItemValueChanged();
        }
    }
}
