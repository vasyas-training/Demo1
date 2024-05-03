using QRCoder;
using QRCoder.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo1App
{
    /// <summary>
    /// Логика взаимодействия для QrPage.xaml
    /// </summary>
    public partial class QrPage : Page
    {
        public QrPage()
        {
            InitializeComponent();
            var QrCodeGenerator = new QRCodeGenerator();
            var qrCodeData = QrCodeGenerator.CreateQrCode("Test", QRCodeGenerator.ECCLevel.L);
            var xamlCode = new XamlQRCode(qrCodeData);
            QrCod.Source = xamlCode.GetGraphic(20);
        }
    }
}
