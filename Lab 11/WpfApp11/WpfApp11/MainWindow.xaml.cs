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
using System.Security.Cryptography;
using System.IO;
using Microsoft.Win32;

namespace WpfApp11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Salt;
        string Hash;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choose = new OpenFileDialog();
            if (choose.ShowDialog() == true)
            {
                hash.Text = File.ReadAllText(choose.FileName);
                Hash = hash.Text;
            }
        }

        private void salt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Salt = salt.Text;
        }

        private void odkryj_Click(object sender, RoutedEventArgs e)
        {
            if (Salt != "" && Hash != "")
            {
                wynik.Text = DecryptString(Hash, Salt);
            }
        }


        public static string DecryptString(string Hash, string encryptionKey)
        {
            byte[] encryptedString = Convert.FromBase64String(Hash);

            using (Aes provider = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                provider.Key = pdb.GetBytes(16);
                provider.IV = pdb.GetBytes(16);
                provider.Mode = CipherMode.CBC;
                provider.Padding = PaddingMode.None;

                using (MemoryStream ms = new MemoryStream(encryptedString))
                {
                    using (CryptoStream cs = new CryptoStream(ms, provider.CreateDecryptor(provider.Key, provider.IV), CryptoStreamMode.Write))
                    {
                        cs.Write(encryptedString, 0, encryptedString.Length);
                        cs.Close();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
}
