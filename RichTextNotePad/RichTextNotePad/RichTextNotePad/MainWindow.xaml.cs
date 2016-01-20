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
using System.IO;

 
 namespace Notepad
 { 
     
     public partial class MainWindow : Window 
     { 
         public MainWindow()
        { 
             InitializeComponent(); 
         } 
         
         private void SelectOpen_Click(object sender, RoutedEventArgs e)
         {    
             OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "Document";
            openFileDialog.DefaultExt = ".txt";
             openFileDialog.Filter = "Text files (.txt)|*.txt";
            Nullable<bool> result = openFileDialog.ShowDialog();
             if (result == true)
            {
                string filename = openFileDialog.FileName;
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            } 
            
         } 
          
         private void SelectSave_Click(object sender, RoutedEventArgs e)
         { 
             SaveFileDialog saveFileDialog = new SaveFileDialog(); 
             saveFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true) 
             File.WriteAllText(saveFileDialog.FileName, textBox.Text); 
         } 
         
         private void SelectClose_Click(object sender, RoutedEventArgs e)
         { 
             if (string.IsNullOrWhiteSpace(textBox.Text)) 
             { 
                 textBox.Text = String.Empty; 
                 Close(); 
             } 
             else 
             { 
                 string messageBoxText = "Save?"; 
                 string caption = "Word Processor"; 
                 MessageBoxButton button = MessageBoxButton.YesNoCancel; 
                 MessageBoxImage icon = MessageBoxImage.Warning; 
                 MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon); 
                 switch (result) 
                 { 
                     case MessageBoxResult.Yes: 
                         SaveFileDialog saveFileDialog = new SaveFileDialog(); 
                         saveFileDialog.Filter = "Text files (*.txt)|*.txt"; 
                         if (saveFileDialog.ShowDialog() == true) 
                             File.WriteAllText(saveFileDialog.FileName, textBox.Text); 
                         break; 
 
 
                     case MessageBoxResult.No: 
                         Close(); 
                         break; 
 
 
                     case MessageBoxResult.Cancel: 
                         break; 
                 } 
             } 
         } 
          
         private void SelectNew_Click(object sender, RoutedEventArgs e)
         { 
             if (string.IsNullOrWhiteSpace(textBox.Text)) 
             { 
                 textBox.Text = String.Empty; 
                 SaveFileDialog saveFileDialog = new SaveFileDialog(); 
                 saveFileDialog.Filter = "Text files (*.txt)|*.txt"; 
                 if (saveFileDialog.ShowDialog() == true) 
                     File.WriteAllText(saveFileDialog.FileName, textBox.Text); 
             } 
             else  
             {            
                 string messageBoxText = "Save?"; 
                 string caption = "Word Processor"; 
                 MessageBoxButton button = MessageBoxButton.YesNoCancel; 
                 MessageBoxImage icon = MessageBoxImage.Warning; 
                 MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon); 
                 switch (result) 
                 { 
                     case MessageBoxResult.Yes: 
                         SaveFileDialog saveFileDialog = new SaveFileDialog(); 
                         saveFileDialog.Filter = "Text files (*.txt)|*.txt"; 
 
 
                         if (saveFileDialog.ShowDialog() == true) 
                             File.WriteAllText(saveFileDialog.FileName, textBox.Text); 
                         break; 
 
 
                     case MessageBoxResult.No: 
                         textBox.Text = String.Empty; 
                         SaveFileDialog newSaveFileDialog = new SaveFileDialog(); 
                         newSaveFileDialog.Filter = "Text files (*.txt)|*.txt"; 
                         if (newSaveFileDialog.ShowDialog() == true) 
                             File.WriteAllText(newSaveFileDialog.FileName, textBox.Text); 
                         break; 
 
 
                     case MessageBoxResult.Cancel: 
                         break; 
                 }
             } 
         } 
     } 
 } 
