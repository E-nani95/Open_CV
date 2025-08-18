using DocumentFormat.OpenXml.Spreadsheet;
using Kiosk_Prototype.Components.Picks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_Prototype.Dialogs
{
    public class DialogBox
    {

        public static DialogResult ShowReceiptDialog(IWin32Window owner, List<PickItem> items)
        {
            IReceiptDialog dialog = new ReceiptDialog();
            dialog.SetItems(items);
            return dialog.ShowDialog(owner);
        }
    }
}
