using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lista5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //listBox1.Width = (panel1.Size.Width / 2);
           // listBox2.Width = (panel1.Size.Width / 2);
        }
        private void przypiszIkone2(string[] pliki) 
        {
            listView1.Items.Clear();
            foreach(string file in pliki)
            {
                if (file.EndsWith(".jpg"))
                    listView1.Items.Add(file, 0);
                else
                    listView1.Items.Add(file, 0);
            }
        }
        private int przypiszIkone(string pliki)
        {
            if (pliki.EndsWith(".bmp") || pliki.EndsWith(".BMP"))
                return 1;            
            else if (pliki.EndsWith(".jpg") || pliki.EndsWith(".JPG"))
                return 2;
            else if (pliki.EndsWith(".png") || pliki.EndsWith(".PNG"))
                return 3;
            else if (pliki.EndsWith(".txt") || pliki.EndsWith(".TXT"))
                return 4;
            else if (pliki.EndsWith(".pdf") || pliki.EndsWith(".PDF"))
                return 5;
            else if (pliki.EndsWith(".gif") || pliki.EndsWith(".GIF"))
                return 6;
            else if (pliki.EndsWith(".avi") || pliki.EndsWith(".AVI") || pliki.EndsWith(".mov") || pliki.EndsWith(".MOV")
                || pliki.EndsWith(".mp4") || pliki.EndsWith(".MP4") || pliki.EndsWith(".mpeg") || pliki.EndsWith(".MPEG"))
                return 7;
            else if (pliki.EndsWith(".doc") || pliki.EndsWith(".DOC"))
                return 8;
            else if (pliki.EndsWith(".exe") || pliki.EndsWith(".EXE"))
                return 9;
            else if (pliki.EndsWith(".msi") || pliki.EndsWith(".MSI"))
                return 10;
            else if (pliki.EndsWith(".dll") || pliki.EndsWith(".DLL"))
                return 11;
            else if (pliki.EndsWith(".cs") || pliki.EndsWith(".CS"))
                return 12;
            else if (pliki.EndsWith(".hdd") || pliki.EndsWith(".HDD"))
                return 13;
            else if (pliki.EndsWith(".bin") || pliki.EndsWith(".BIN"))
                return 14;
            else if (pliki.EndsWith(".lnk") || pliki.EndsWith(".LNK"))
                return 15;
            else
                return 16;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ids = Directory.GetLogicalDrives();
            foreach (string id in ids)
            {
                DriveInfo dysk = new DriveInfo(id);
                string ext1 = "DYSK";
            // if (Path.GetExtension(id) == "") ext1 = "Folder";
            //else ext1 = Path.GetExtension(id);
            string idLoad = @"C:\Users\Damian\Documents\NET\Lista5";
                ListViewItem item = new ListViewItem(new[] {
                        idLoad
                        , ext1
                        , (dysk.TotalSize/(1024*1024*1024)).ToString() + "GB"
                        , "---"
                        , "---"
                        , idLoad}, 13);
                listView1.Items.Add(item);
                label1.Text = (dysk.TotalFreeSpace/1024).ToString() +"kB wolne z "+ (dysk.TotalSize/1024).ToString();
                label2.Text = id;

                ListViewItem item2 = new ListViewItem(new[] {
                        idLoad
                        , ext1
                        , (dysk.TotalSize/(1024*1024*1024)).ToString() + "GB"
                        , "---"
                        , "---"
                        , idLoad}, 13);
                listView2.Items.Add(item2);
                label3.Text = (dysk.TotalFreeSpace / 1024).ToString() + "kB wolne z " + (dysk.TotalSize / 1024).ToString();
                label4.Text = id;              
            }
        }
        
        private string GetAtr(string paf)
        {
            string atr = "";
            FileAttributes attributes = File.GetAttributes(paf);
            if (attributes.HasFlag(FileAttributes.Directory))
                atr += "d";
            else
                atr += "-";
            if (attributes.HasFlag(FileAttributes.ReadOnly))
                atr += "r";
            else
                atr += "-";
            if (attributes.HasFlag(FileAttributes.System))
                atr += "s";
            else
                atr += "-";
            if (attributes.HasFlag(FileAttributes.Hidden))
                atr += "u";
            else
                atr += "-";
            if (attributes.HasFlag(FileAttributes.Encrypted))
                atr += "e";
            else
                atr += "-";
            if (attributes.HasFlag(FileAttributes.Archive))
                atr += "a";
            else
                atr += "-";

            return atr;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(listView1.Items.ToString(), "1111: ");
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    // MessageBox.Show(listView1.SelectedItems[0].SubItems[5].Text);
                    listView1.FullRowSelect = true;
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Błąd List 1 SelIndChange: ");

            }
        }
        string rootDirL1;
        string sciezkaL1 = @"C:\";
        string sL1 = "";
        private void f()
        {
            try
            {
                
                // listView1.Columns["Nazwa"].SelectedItems[0].Text;//  SelectedItems[0].Text;
                //  MessageBox.Show(listView1.Items[0].Text, "333: ");
                if (listView1.SelectedItems.Count > 0)
                {
                    sL1 = listView1.SelectedItems[0].SubItems[5].Text;
                    //  MessageBox.Show(s, "4444: ");
                    sciezkaL1 = sL1;
                    //   MessageBox.Show(sciezka, "555: ");
                }


                FileAttributes attrF = File.GetAttributes(sciezkaL1);
                if (!attrF.HasFlag(FileAttributes.Directory))
                {
                    sciezkaL1 = Path.GetFullPath(Path.Combine(sciezkaL1, @"..\"));
                    //MessageBox.Show(sciezkaL1, "F111====2222: ");
                }
                label2.Text = sciezkaL1;
                //MessageBox.Show(sciezkaL1, "F1111: ");
                string extL1 = "";
                string[] dirs = { Path.GetFullPath(Path.Combine(sciezkaL1, @"..\")) };
                               
                FileAttributes attr = File.GetAttributes(sciezkaL1);
                 if (!attr.HasFlag(FileAttributes.Directory))
                //if (Path.GetExtension(sciezkaL1) != "")
                {
                    System.Diagnostics.Process.Start(sciezkaL1);
                    sciezkaL1 = Path.Combine(sciezkaL1, @"..\");               
                }
                else
                {
                    // MessageBox.Show(sciezkaL1 + " = '" + Path.GetExtension(sciezkaL1) + "'", "f(): IF");
                    //System.Diagnostics.Process.Start( sciezkaL1);
                    //return ;
                    listView1.Items.Clear();
                    try
                    {
                        dirs = Directory.GetDirectories(sciezkaL1);
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message + sciezkaL1, "f(): dirs");
                    }
                    rootDirL1 = Path.GetFullPath(Path.Combine(sciezkaL1, @"..\"));
                    ListViewItem item3 = new ListViewItem(new[] {
                        "[..]"
                        , " "
                        , "<DIR>"
                        , Directory.GetLastWriteTimeUtc(sciezkaL1).ToString()
                        , Directory.GetCreationTimeUtc(sciezkaL1).ToString()
                        , rootDirL1
                        ,"------"}, 0);
                    listView1.Items.Add(item3);
                    foreach (string dir in dirs)
                    {
                        //if (Path.GetExtension(dir) == "") ext = "Folder";
                        // else ext =  Path.GetExtension(dir);
                        ListViewItem item = new ListViewItem(new[] {
                        Path.GetFileName(dir)
                        , " "
                        , "<DIR>"
                        , Directory.GetLastWriteTimeUtc(dir).ToString()
                        , Directory.GetCreationTimeUtc(dir).ToString()
                        , dir
                        ,"------"}, 0);
                        listView1.Items.Add(item);
                        //listView1.Items.Add(Path.GetFileName(dir), 1).SubItems.Add(dir).SubItems.Add(dir); 
                        //listView1.Items.Add("path").SubItems.Add(dir);
                    }
                    string[] filePath = Directory.GetFiles(sciezkaL1);

                    string rozmiarL1 = "";
                    // if (sciezka != @"C:\") rozmiar = (fi.Length / 1024).ToString();
                    foreach (string id in filePath)
                    {
                        //listView1.Items.Add(Path.GetFileName(id), 1); 
                        //if (Path.GetExtension(id) == "") ext = "Folder";
                        //else ext = Path.GetExtension(id);
                        FileInfo fi = new FileInfo(id);
                        // DateTime fi1 = File.GetLastWriteTimeUtc(id).ToString();
                        ListViewItem item = new ListViewItem(new[] {
                        Path.GetFileName(id)
                        , Path.GetExtension(id)
                        , ((fi.Length / 1024).ToString()).PadRight(3) + "k"
                        , File.GetLastWriteTimeUtc(id).ToString()
                        , File.GetCreationTimeUtc(id).ToString()
                        , id
                        , GetAtr(id)}, przypiszIkone(id));
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "f: ");

            }
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            f();
        }

        string rootDirL2;
        string sciezkaL2 = @"C:\";
        string sL2 = "";
        private void f2()
        {
            try
            {

              //  FileAttributes PafAttrF = File.GetAttributes(sciezkaL2);
                //if (PafAttrF.HasFlag(FileAttributes.Directory))
                if (true)
                { 
                    // listView2.Columns["Nazwa"].SelectedItems[0].Text;//  SelectedItems[0].Text;
                    //  MessageBox.Show(listView2.Items[0].Text, "333: ");
                    if (listView2.SelectedItems.Count > 0)
                    {
                        ListView.SelectedListViewItemCollection paf = listView2.SelectedItems;
                        sL2 = listView2.SelectedItems[0].SubItems[5].Text;
                       // MessageBox.Show("sL2=" + sL2 + "\nsciezkaL2=" + sciezkaL2 + "\nlabel4.text=" + label4.Text + "\npaf=" + paf[0], "4444: ");
                        //MessageBox.Show(sL2, "4444: ");
                        sciezkaL2 = sL2;
                        //   MessageBox.Show(sciezkaL2, "555: ");
                    }
                //sciezkaL2 = Path.Combine(sciezkaL2, @"..\");

                FileAttributes attrF = File.GetAttributes(sciezkaL2);
                if (!attrF.HasFlag(FileAttributes.Directory))
                {
                    sciezkaL2 = Path.GetFullPath(Path.Combine(sciezkaL2, @"..\"));
                    // MessageBox.Show(sciezkaL2, "44: ");
                }
                label4.Text = sciezkaL2;
                //MessageBox.Show(sciezkaL2, "555: ");
                string extL2 = "";
                string[] dirs = { Path.GetFullPath(Path.Combine(sciezkaL2, @"..\")) };

                FileAttributes attr = File.GetAttributes(sciezkaL2);
                if (!attr.HasFlag(FileAttributes.Directory))
                //if (Path.GetExtension(sciezkaL2) != "")
                {
                    System.Diagnostics.Process.Start(sciezkaL2);
                    sciezkaL2 = Path.Combine(sciezkaL2, @"..\");
                }
                else
                {
                    // MessageBox.Show(sciezkaL2 + " = '" + Path.GetExtension(sciezkaL2) + "'", "f(): IF");
                    //System.Diagnostics.Process.Start( sciezkaL2);
                    //return ;
                    listView2.Items.Clear();
                    try
                    {
                        dirs = Directory.GetDirectories(sciezkaL2);
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message + sciezkaL2, "f(): dirs");
                    }
                    rootDirL2 = Path.GetFullPath(Path.Combine(sciezkaL2, @"..\"));
                    ListViewItem item3 = new ListViewItem(new[] {
                        "[..]"
                        , " "
                        , "<DIR>"
                        , Directory.GetLastWriteTimeUtc(sciezkaL2).ToString()
                        , Directory.GetCreationTimeUtc(sciezkaL2).ToString()
                        , rootDirL2
                        ,"------"}, 0);
                    listView2.Items.Add(item3);
                    foreach (string dir in dirs)
                    {
                        //if (Path.GetExtension(dir) == "") ext = "Folder";
                        // else ext =  Path.GetExtension(dir);
                        ListViewItem item = new ListViewItem(new[] {
                        Path.GetFileName(dir)
                        , " "
                        , "<DIR>"
                        , Directory.GetLastWriteTimeUtc(dir).ToString()
                        , Directory.GetCreationTimeUtc(dir).ToString()
                        , dir
                        ,"------"}, 0);
                        listView2.Items.Add(item);
                        //listView2.Items.Add(Path.GetFileName(dir), 2).SubItems.Add(dir).SubItems.Add(dir); 
                        //listView2.Items.Add("path").SubItems.Add(dir);
                    }
                    string[] filePath = Directory.GetFiles(sciezkaL2);

                    string rozmiarL2 = "";
                    // if (sciezka != @"C:\") rozmiar = (fi.Length / 1024).ToString();
                    foreach (string id in filePath)
                    {
                        //listView2.Items.Add(Path.GetFileName(id), 2); 
                        //if (Path.GetExtension(id) == "") ext = "Folder";
                        //else ext = Path.GetExtension(id);
                        FileInfo fi = new FileInfo(id);
                        // DateTime fi2 = File.GetLastWriteTimeUtc(id).ToString();
                        ListViewItem item = new ListViewItem(new[] {
                        Path.GetFileName(id)
                        , Path.GetExtension(id)
                        , ((fi.Length / 1024).ToString()).PadRight(3) + "k"
                        , File.GetLastWriteTimeUtc(id).ToString()
                        , File.GetCreationTimeUtc(id).ToString()
                        , id
                        , GetAtr(id)}, przypiszIkone(id));
                        listView2.Items.Add(item);

                    }
                }
            }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "f2: ");
            }
        }
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView2.SelectedItems.Count > 0)
                {
                   //  MessageBox.Show(listView2.Activation.ToString());
                    listView2.FullRowSelect = true;
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Błąd List 2 SelIndChange: ");

            }
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                f();
            }   
        }

        private void listView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                f2();
            }
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            f2();
        }

        private async void But(ListView source, string destiny)
        {
            ListView.SelectedListViewItemCollection zaznaczone = source.SelectedItems;
            if(zaznaczone.Count == 0)
            {
                MessageBox.Show("Nie zaznaczono nieczego"  , "But");
                return;
            }
            //string sourceDirPath = "";
            foreach (ListViewItem item in zaznaczone)
            {
                //sourceDirPath += "\nitem.SubItems[5].Text=" + item.SubItems[5].Text.ToString();
                var sourceDirPath = Path.Combine( item.SubItems[5].Text);
                var sourceDirectoryInfo = new DirectoryInfo(item.SubItems[5].Text);

                var targetDirPath = Path.Combine(destiny);
                var targetDirectoryInfo = new DirectoryInfo(targetDirPath);
                //  FileAttributes attr = File.GetAttributes(item.SubItems[5].Text);
                // if (attr.HasFlag(FileAttributes.Directory))
                //  {
                // sourceDirPath = item.SubItems[5].Text;
                //    DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(item.SubItems[5].Text);
                    MessageBox.Show("sourceDirPath=" + sourceDirPath + "\ntargetDirPath="+ targetDirPath, "But");
                await Task.Run(() => CopyFiles(item.SubItems[5].Text, targetDirectoryInfo));
                   // continue;
               // }
               // await Task.Run(() => CopyFiles(item.SubItems[5].Text, targetDirectoryInfo));
            }
            
        }

        private void CopyFiles(string source, DirectoryInfo target)
        {
            try
            {
                FileInfo file = new FileInfo(source);
               
                    if (File.Exists(Path.Combine(target.FullName, file.Name)))
                    {
                        if (DialogResult.Yes == MessageBox.Show(Path.GetFileName(Path.Combine(target.FullName, file.Name)) + " istnieje. Zastąpić?", "Plik istnieje", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            file.CopyTo(Path.Combine(target.FullName, file.Name), true);
                    }
                    else
                        file.CopyTo(Path.Combine(target.FullName, file.Name), false);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Błąd Kopiowania!");
            }
        }
        private void CopyFiles(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(target.FullName, source.Name));
                //Directory.CreateDirectory(target.FullName);

                foreach (var file in source.GetFiles())
                {
                    if (File.Exists(Path.Combine(target.FullName, source.Name, file.Name)))
                    //if (File.Exists(target.FullName))
                    {
                        if (DialogResult.Yes == MessageBox.Show(Path.Combine(target.FullName, source.Name,  file.Name) + " istnieje. Zastąpić?", "Plik istnieje", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            file.CopyTo(Path.Combine(target.FullName, source.Name, file.Name), true);
                            MessageBox.Show("target=" + Path.Combine(target.FullName, source.Name, file.Name), "COPY FILES");
                        }
                    }
                    else
                    {
                        file.CopyTo(Path.Combine(target.FullName, source.Name, file.Name), false);
                        MessageBox.Show("target=" + Path.Combine(target.FullName, source.Name, file.Name), "COPY FILES222222");
                    }
                }

              /*  foreach (var sourceSubDirectory in source.GetDirectories())
                {
                    var targetSubDirectory = target.CreateSubdirectory( sourceSubDirectory.Name);
                    MessageBox.Show("target=" + Path.Combine(sourceSubDirectory.Name), "COPY FILES33333333");
                    CopyFiles(sourceSubDirectory, targetSubDirectory);
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Błąd Kopiowania!");
            }
        }

        private void KopyFolders(ListView LV, string dirCopyDo)
        {
            try
            {
                string dirCopyZ;

                ListView.SelectedListViewItemCollection zaznaczone = LV.SelectedItems;
                if (zaznaczone.Count == 0)
                {
                    MessageBox.Show("Nie zaznaczono nieczego", "But");
                    return;
                }
                //string sourceDirPath = "";
                foreach (ListViewItem item in zaznaczone)
                {
                    string file = item.SubItems[5].Text;
                    //string[] plikiŹródła = Directory.GetFiles(dirCopyZ);

                   // foreach (string file in plikiŹródła)
                   // {
                        string fileName = Path.GetFileName(file);
                        if (File.Exists(file))
                        {
                            if (DialogResult.Yes == MessageBox.Show(Path.GetFileName(file) + " exists. Replace?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                File.Copy(file, dirCopyDo + "\\" + fileName, true);
                        }
                        else
                            File.Copy(file, dirCopyDo + "\\" + fileName, false);
                         File.Delete(file);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Błąd Przenoszenia!");
            }
        }
        private void MoveFolders(string dirCopyZ, string dirCopyDo)
        {
            try
            {
                string[] plikiŹródła = Directory.GetFiles(dirCopyZ);                

                foreach (string file in plikiŹródła)
                {
                    string fileName = Path.GetFileName(file);
                    if (File.Exists(fileName))
                    {
                        if (DialogResult.Yes == MessageBox.Show(Path.GetFileName(fileName) + " exists. Replace?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            File.Copy(file, dirCopyDo + "\\" + fileName, true);
                    }
                    else
                        File.Copy(file, dirCopyDo + "\\" + fileName, false);
                    File.Delete(file);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Błąd Przenoszenia!");
            }
        }

        private void wytnijToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            But(listView1, label4.Text);
            f2();
            f();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            But(listView2, label2.Text);
            f();
            f2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Niezaznaczono pliku", "Brak zaznaczenia pliku");
                return;
            }

            ListView.SelectedListViewItemCollection zaznaczone = listView1.SelectedItems;
            string src;//= Path.Combine(label2.Text, zaznaczone[0].Text);
            // MessageBox.Show("src=" + src, "src");
            string dest;//= Path.Combine(label4.Text, zaznaczone[0].Text);
           // MessageBox.Show("dest=" + dest, "dest");

            try
            {
                KopyFolders(listView1, label4.Text);
                /* foreach(ListViewItem paf in zaznaczone)
                 {
                     src = Path.Combine(label2.Text, paf.Text);
                     //MessageBox.Show("src=" + src, "src");
                     dest = Path.Combine(label4.Text, paf.Text);
                     //MessageBox.Show("src=" + src+"\ndest=" + dest, "dest");
                      File.Move(src, dest);

                     if (!File.Exists(src))
                     {
                        // MessageBox.Show("File successfully MOVED.");
                     }
                 }*/
                f();
                f2();
            }
            catch (IOException ex)
            {
                Console.WriteLine("The renaming failed: {0}", ex.ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Path.Combine(label4.Text, textBox1.Text ));
            textBox1.Text = "";
            f2();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Path.Combine(label2.Text, textBox1.Text));
            textBox1.Text = "";
            f();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Path.Combine(label4.Text, textBox1.Text)))
            {
                File.Create(Path.Combine(label4.Text, textBox1.Text));
                textBox1.Text = "";
                f2();
                return;
            }

            if (DialogResult.Yes == MessageBox.Show(File.Exists(Path.Combine(label4.Text, textBox1.Text))
                + " exists. Replace?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) 
            {
                File.Create(Path.Combine(label4.Text, textBox1.Text));
                textBox1.Text = "";
                f2();
                return;
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Path.Combine(label2.Text, textBox1.Text)))
            {
                File.Create(Path.Combine(label2.Text, textBox1.Text));
                textBox1.Text = "";
                f();
                return;
            }

            if (DialogResult.Yes == MessageBox.Show(File.Exists(Path.Combine(label2.Text, textBox1.Text))
                + " exists. Replace?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                File.Create(Path.Combine(label2.Text, textBox1.Text));
                textBox1.Text = "";
                f();
                return;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Niepodano nowej nazwy", "Brak nowej nazwy pliku");
                return;
            }
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Niezaznaczono pliku", "Brak zaznaczenia pliku");
                return;
            }
            if (listView1.SelectedItems.Count > 1)
            {
                MessageBox.Show("Zaznaczono za dużo plików", "Zaznaczono za dużo plików");
                return;
            }

            ListView.SelectedListViewItemCollection zaznaczone = listView1.SelectedItems;
            string src = Path.Combine(label2.Text , zaznaczone[0].Text);
           // MessageBox.Show("src=" + src, "src");
            string dest = Path.Combine(label2.Text, textBox1.Text);
            //MessageBox.Show("dest=" + Path.Combine(label2.Text, textBox1.Text), "dest");

            try
            {
                File.Move(src, dest);

                if (!File.Exists(src))
                {
                    Console.WriteLine("File successfully renamed.");
                }
                textBox1.Text = "";
                f();
            }
            catch (IOException ex)
            {
                Console.WriteLine("The renaming failed: {0}", ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Niepodano nowej nazwy", "Brak nowej nazwy pliku");
                return;
            }
            if (listView2.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Niezaznaczono pliku", "Brak zaznaczenia pliku");
                return;
            }
            if (listView2.SelectedItems.Count > 1)
            {
                MessageBox.Show("Zaznaczono za dużo plików", "Zaznaczono za dużo plików");
                return;
            }

            ListView.SelectedListViewItemCollection zaznaczone = listView2.SelectedItems;
            string src = Path.Combine(label4.Text, zaznaczone[0].Text);
           // MessageBox.Show("src=" + src, "src");
            string dest = Path.Combine(label4.Text, textBox1.Text);
           // MessageBox.Show("dest=" + Path.Combine(label4.Text, textBox1.Text), "dest");

            try
            {
                File.Move(src, dest);

                if (!File.Exists(src))
                {
                    Console.WriteLine("File successfully renamed.");
                }
                textBox1.Text = "";
                f2();
                f();
            }
            catch (IOException ex)
            {
                Console.WriteLine("The renaming failed: {0}", ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Niezaznaczono pliku", "Brak zaznaczenia pliku");
                return;
            }

            ListView.SelectedListViewItemCollection zaznaczone = listView2.SelectedItems;
            string src;//= Path.Combine(label2.Text, zaznaczone[0].Text);
            // MessageBox.Show("src=" + src, "src");
            string dest;//= Path.Combine(label4.Text, zaznaczone[0].Text);
                        // MessageBox.Show("dest=" + dest, "dest");

            try
            {

                KopyFolders(listView2, label2.Text);

                f();
                f2();
            }
            catch (IOException ex)
            {
                Console.WriteLine("The renaming failed: {0}", ex.ToString());
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Niepodano nowej nazwy", "Brak nowej nazwy ");
                return;
            }
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Niezaznaczono ", "Brak zaznaczenia ");
                return;
            }
            if (listView1.SelectedItems.Count > 1)
            {
                MessageBox.Show("Zaznaczono za dużo ", "Zaznaczono za dużo ");
                return;
            }

            ListView.SelectedListViewItemCollection zaznaczone = listView1.SelectedItems;
            string src;
            string dest;

            src = Path.Combine(label2.Text, zaznaczone[0].Text);
           // MessageBox.Show("label2.Text="+ label2.Text +"\nzaznaczone[0].Text=" + zaznaczone[0].Text, "src");
            // MessageBox.Show("src=" + src, "src");
            dest = Path.Combine(label2.Text, textBox1.Text);
            //MessageBox.Show("dest=" + Path.Combine(label2.Text, textBox1.Text), "dest");

            try
            {
                Directory.Move(src, dest);

                textBox1.Text = "";
                f();
            }
            catch (IOException ex)
            {
                Console.WriteLine("The renaming failed: {0}", ex.ToString());
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Niepodano nowej nazwy", "Brak nowej nazwy ");
                return;
            }
            if (listView2.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Niezaznaczono ", "Brak zaznaczenia ");
                return;
            }
            if (listView2.SelectedItems.Count > 1)
            {
                MessageBox.Show("Zaznaczono za dużo ", "Zaznaczono za dużo ");
                return;
            }

            ListView.SelectedListViewItemCollection zaznaczone = listView2.SelectedItems;
            string src;
            string dest;

            src = Path.Combine(label4.Text, zaznaczone[0].Text);
            // MessageBox.Show("label2.Text="+ label2.Text +"\nzaznaczone[0].Text=" + zaznaczone[0].Text, "src");
            // MessageBox.Show("src=" + src, "src");
            dest = Path.Combine(label4.Text, textBox1.Text);
            //MessageBox.Show("dest=" + Path.Combine(label2.Text, textBox1.Text), "dest");

            try
            {
                Directory.Move(src, dest);

                textBox1.Text = "";
                f2();
            }
            catch (IOException ex)
            {
                Console.WriteLine("The renaming failed: {0}", ex.ToString());
            }
        }
    }
}
