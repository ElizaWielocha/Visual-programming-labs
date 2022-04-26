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
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Windows.Interop;



namespace lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage start_img = new BitmapImage(); // reseting the changes in function: reset_Click()
        private double RotateAngle = 0.0;  // increasing in function: lustro_click()
        public MainWindow()
        {
            InitializeComponent();
        }

        
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri file = new Uri(openFileDialog.FileName);
                image1.Source = new BitmapImage(file); // control image
                start_img = new BitmapImage(file);   // create to reset the changes 

            }
        }

        bool click;
        private void lustro_Click(object sender, RoutedEventArgs e)
        {
            click = !click;

            if (click)
            {
                image1.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5); // image is changing in the same place (doesn't change the position in window)
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = -1;  // flip horizontally, flipTrans.ScaleY = -1; -> vertically
                image1.RenderTransform = flipTrans;
            }
            else
            {
                image1.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5); // image is changing in the same place (doesn't change the position in window)
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = 1;  // flip horizontally on the other side
                image1.RenderTransform = flipTrans;
            }
          
        }


        public void obrot_Click(object sender, RoutedEventArgs e)
        {
            
            image1.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5); // image is changing in the same place (doesn't change the position in window)
            RotateTransform rotateTransform = new RotateTransform(RotateAngle += 90); // adding 90's degres for every click button to rotate more then once
            image1.RenderTransform = rotateTransform;
        }



        private void zielony_Click(object sender, RoutedEventArgs e)
        {

            var data = new DataObject(DataFormats.Bitmap, image1.Source, true);
            var bmp = data.GetData("System.Drawing.Bitmap") as System.Drawing.Bitmap; // creating the Bitmap form the BitmapImage (image1.Source) and getting the data

            int width = (int)bmp.Width;
            int height = (int)bmp.Height; // creating the int's for the height and width of the image

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++) // looping for every element of width and height
                {
                    System.Drawing.Color p = bmp.GetPixel(x, y); // getting the pixels of every element

                    int r = p.R;
                    int g = p.G;
                    int b = p.B;  // creating the int's for the red-color, green-color and blue-color of the pixel

                    if ( r > 200 )    // checking if the pixels are the green shade - if not, then changing them to white/black/gray
                    {
                        bmp.SetPixel(x, y, System.Drawing.Color.Gray);
                    }
                    else if (g < 130)
                    {
                        bmp.SetPixel(x, y, System.Drawing.Color.DarkGray);
                    }
                    else if (b > 130)
                    {
                         bmp.SetPixel(x, y, System.Drawing.Color.Black);
                    }
                }
            }

            MemoryStream ms = new MemoryStream();           // changing the Bitmap to the BitmapImage 
            ((System.Drawing.Bitmap)bmp).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();

            image1.Source = image;   // new apperance of the image control
        }




        private void negatyw_Click(object sender, RoutedEventArgs e)
        {
            var data = new DataObject(DataFormats.Bitmap, image1.Source, true);
            var bmp = data.GetData("System.Drawing.Bitmap") as System.Drawing.Bitmap;

            int width = (int)bmp.Width;
            int height = (int)bmp.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    System.Drawing.Color p = bmp.GetPixel(x, y);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    r = 255 - r;   // to create negativ -> 255 - the red/green/blue color is negativ of this pixel
                    g = 255 - g;
                    b = 255 - b;

                    bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, r, g, b)); // set the new color pixel
                }
            }

            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)bmp).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();  

            image1.Source = image;
        }

        private void reset_Click(object sender, RoutedEventArgs e)  //function to reset the negativ and green changes
        {
            image1.Source = start_img;  
        }
    }
}
