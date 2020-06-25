using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Face_Detection_Open_CV
{

    public partial class Form1 : Form
    {
        #region global values
        //değişkeni tanıtalım tüm projede kullanılacak
        MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);
        HaarCascade faceDetected; //face yakalama
        Image<Bgr, Byte> Frame; //çerçeve
        Capture camera;//
        Image<Gray, byte> result;
        Image<Gray, byte> TrainedFace = null;
        Image<Gray, byte> grayface = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> Users = new List<string>();
        string name= null;
        #endregion

        private void button2_Click(object sender, EventArgs e) //kaydetme
        {    
            grayface = camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            MCvAvgComp[][] detectedFaces = grayface.DetectHaarCascade(faceDetected, 1.3, 8, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach(MCvAvgComp f in detectedFaces[detectedFaces.Length-1])
            {
                TrainedFace = Frame.Copy(f.rect).Convert<Gray, byte>();
                break;
            }
            TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_NN);
            trainingImages.Add(TrainedFace);
            labels.Add(textname.Text);
            for(int i=1;i<trainingImages.ToArray().Length+1;i++)  trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "\\Faces\\"+textname.Text+ ".bmp");

            listBox1.Items.Add(textname.Text);
            listboxkaydet(listBox1, Application.StartupPath + "\\faces\\Faces.txt");
            MessageBox.Show(textname.Text + " added successfully");

            //combobox iceriğini yukle
            foreach (string f in listBox1.Items)
            {
                comboBox1.Items.Add(f);
            }
        }

        private void save_face(string isim)
        {
            grayface = camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            MCvAvgComp[][] detectedFaces = grayface.DetectHaarCascade(faceDetected, 1.3, 8, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp f in detectedFaces[detectedFaces.Length - 1])
            {
                TrainedFace = Frame.Copy(f.rect).Convert<Gray, byte>();
                break;
            }
            TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            trainingImages.Add(TrainedFace);
            labels.Add(isim);
            for (int i = 1; i < trainingImages.ToArray().Length + 1; i++) trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "\\Faces\\" + isim + ".bmp");
            listBox1.Items.Add(isim);
        }

        public Form1() //nothing here, Initializing the component
        {
            InitializeComponent();            
        }

        //bool[] compaire= { false, false, false, false, false};
        //int bak = 0;
        //public bool recognition_all(string isim)
        //{
        //    for (int i = 0; i < listBox1.Items.Count; i++)
        //    {
        //        if (listBox1.Items[i].ToString() == isim) compaire[i] = true;
        //    }
        //    for (int i = 0; i < compaire.Length; i++) if (compaire[i]) bak++;
        //    progressBar1.Value = bak;
        //    if (bak > 4) { bak = 0; return true; } else { bak = 0; return false; }            
        //} cancelled to use

        private void frameProcedure(object sender, EventArgs e)
        {
            Frame = camera.QueryFrame().Resize(640, 480, Emgu.CV.CvEnum.INTER.CV_INTER_NN);
            grayface = Frame.Convert<Gray, byte>();
            MCvAvgComp[][] facesDetectedNow = grayface.DetectHaarCascade(faceDetected, 1.3, 6, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DEFAULT, new Size());
            foreach (MCvAvgComp f in facesDetectedNow[facesDetectedNow.Length-1])
            {
                result = Frame.Copy(f.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_NN);
                Frame.Draw(f.rect, new Bgr(Color.Green),2);
                if (trainingImages.ToArray().Length != 0)
                {
                    MCvTermCriteria termCriteria = new MCvTermCriteria(listBox1.Items.Count, 0.01);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 1500, ref termCriteria);
                    name=recognizer.Recognize(result);
                    Frame.Draw(name, ref font, new Point(f.rect.X, f.rect.Y - 5), new Bgr(Color.DeepSkyBlue));

                    if ((name == comboBox1.Text) & (name!="")) permission.Visible = true; else permission.Visible = false;
                    if (name == "") 
                    Frame.Draw("unknown Face", ref font, new Point(f.rect.X, f.rect.Y - 5), new Bgr(Color.Red));
                }
            }
            cameraBox.Image = Frame;  
        } //recognition is processing here
         
        private void listboxkaydet(ListBox adi,string yolu) //saving listbox to a txt file
        {
            using (System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(yolu))
            {
                foreach (var item in adi.Items)
                    SaveFile.WriteLine(item.ToString());
            }
        }        

        private void listboxyukle(ListBox adi, string yolu) //loading txt file to the listbox
        {
                FileInfo file = new FileInfo(yolu);
                StreamReader stRead = file.OpenText();
                while (!stRead.EndOfStream)
                {
                    adi.Items.Add(stRead.ReadLine());
                }
                stRead.Close();
        }

        public Image byteArrayToImage(byte[] byteArrayIn) //deleting the picture becomes error so wrote this code
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void Clearlist_Click(object sender, EventArgs e) //deleting the selected items include the bmp file and txt..
        {  
            int i = listBox1.SelectedIndex;
            string deledtedface = listBox1.Items[i].ToString();
            if (File.Exists(Application.StartupPath + "\\Faces\\" + listBox1.Items[i].ToString() + ".bmp"))
            File.Delete(Application.StartupPath + "\\Faces\\" + listBox1.Items[i].ToString() + ".bmp");
            listBox1.Items.RemoveAt(i);
            listBox1.Update();
            listboxkaydet(listBox1, Application.StartupPath + "\\faces\\Faces.txt");
            MessageBox.Show(deledtedface+ " deleted successfully");
        } 

        private void Form1_Load(object sender, EventArgs e)//while form loading
        {
            //haarcascede yüz tanıma için kullanılan dosya
            faceDetected = new HaarCascade("haarcascade_frontalface_default.xml");
            if (File.Exists(Application.StartupPath + "\\faces\\Faces.txt"))
            listboxyukle(listBox1, Application.StartupPath + "\\faces\\Faces.txt");
           
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (File.Exists(Application.StartupPath + "\\Faces\\" + listBox1.Items[i].ToString() + ".bmp"))
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "\\Faces\\" + listBox1.Items[i].ToString() + ".bmp"));
                labels.Add(listBox1.Items[i].ToString());
            }
            //start detection and recognization
            camera = new Capture();
            camera.QueryFrame();
            Application.Idle += new EventHandler(frameProcedure);

            //combobox iceriğini yukle
            foreach (string f in listBox1.Items)
            {
                comboBox1.Items.Add(f);
            }

        }

        private void listBox1_Click(object sender, EventArgs e)//listbox1 click events
        {
            byte[] imageAsByteArray;
            if (File.Exists(Application.StartupPath + "\\Faces\\" + listBox1.Items[listBox1.SelectedIndex].ToString() + ".bmp"))
            {
                imageAsByteArray = File.ReadAllBytes(Application.StartupPath + "\\Faces\\" + listBox1.Items[listBox1.SelectedIndex].ToString() + ".bmp");
                gray_pictureBox.Image = byteArrayToImage(imageAsByteArray);
            }
        }

    }
}
