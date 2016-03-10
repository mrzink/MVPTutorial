//using Common.Constant;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Globalization;
//using System.Linq;
//using System.Resources;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Common
//{
//    /******************************************************************
//     C# JCS Coding conventions 
//     * File Name : ResourceSetting.cs * 
//     * Create by : PhuongDQ *   
//     * Create date : 2015/09/19 *
//     * Update by :  * 
//     * Update date : * 
//     ******************************************************************/
//    public class ResourceSetting
//    {
//        public static ResourceManager Resources { get; set; }

//        public static CultureInfo CultureInfos { get; set; }

//        /// <summary>
//        /// change CultureInfo
//        /// </summary>
//        /// <param name="cul">culture</param>
//        public static void ChangeResource(string cul)
//        {
//            CultureInfos = new CultureInfo(cul);
//            Thread.CurrentThread.CurrentCulture = CultureInfos;
//            Thread.CurrentThread.CurrentUICulture = CultureInfos;
//        }

//        /// <summary>
//        /// load resource files
//        /// </summary>
//        public static void LoadResource()
//        {
//           // Resources = ResourceManager.CreateFileBasedResourceManager(FilePaths.appName, Application.StartupPath + FilePaths.filePathResourceClient, null);
//        }

//        /// <summary>
//        /// change multilanguage
//        /// </summary>
//        /// <param name="form"></param>
//        public static void ChangeLanguage(Form form)
//        {
//            try
//            {
//                // change font 
//                Font font = ChangeFont(Thread.CurrentThread.CurrentCulture, form);
//                form.Font = font;

//                //change item display name
//                form.Text = Resources.GetString(form.Name);
//                foreach (Control item in form.Controls)
//                {
//                    if (item is TextBox || item is DateTimePicker || item is ComboBox
//                        || item is PictureBox || item is ToolStrip || item is Panel || item is RichTextBox)
//                    {
//                        item.Font = font;
//                    }
//                    else
//                    {
//                        if (item is TabControl)
//                        {
//                            foreach (Control tabPage in item.Controls)
//                            {
//                                tabPage.Font = font;
//                                tabPage.Text = Resources.GetString(tabPage.Name);
//                                foreach (Control tabPageItem in tabPage.Controls)
//                                {
//                                    if (tabPageItem is TextBox || tabPageItem is DateTimePicker || tabPageItem is ComboBox)
//                                    {
//                                        item.Font = font;
//                                    }
//                                    else
//                                    {
//                                        tabPageItem.Font = font;
//                                        tabPageItem.Text = Resources.GetString(tabPageItem.Name);
//                                    }
//                                }
//                            }
//                        }
//                        else
//                        {
//                            if (item is DataGridView)
//                            {
//                                foreach (DataGridViewColumn column in ((DataGridView)item).Columns)
//                                {
//                                    column.HeaderText = Resources.GetString(column.Name);
//                                }
//                            }
//                            else
//                            {
//                                if (item is GroupBox)
//                                {
//                                    item.Text = Resources.GetString(item.Name);
//                                    foreach (Control gritem in ((GroupBox)item).Controls)
//                                    {
//                                        if (gritem is Label || gritem is RadioButton || (gritem is Button && gritem.Text != string.Empty))
//                                        {
//                                            gritem.Text = Resources.GetString(gritem.Name);
//                                            gritem.Font = font;
//                                        }
//                                    }
//                                }
//                                else
//                                {
//                                    item.Text = Resources.GetString(item.Name);
//                                    if (item.Font.Bold)
//                                    {
//                                        item.Font = new Font(font.FontFamily, font.Size, FontStyle.Bold);
//                                    }
//                                    else
//                                    {
//                                        item.Font = font;
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        /// <summary>
//        /// change font depend on language
//        /// </summary>
//        /// <param name="cul"></param>
//        /// <param name="f"></param>
//        /// <returns></returns>
//        private static Font ChangeFont(CultureInfo cul, Form f)
//        {
//            Font font;
//            switch (cul.ToString())
//            {
//                case FilePaths.cultureDefault:
//                    font = new Font(FilePaths.timeNewRoman, f.Font.Size);
//                    break;
//                default:
//                    font = new Font(FilePaths.msGothic, f.Font.Size);
//                    break;
//            }
//            return font;
//        }

//        /// <summary>
//        /// get validateString
//        /// </summary>
//        /// <param name="errorMessage"></param>
//        /// <param name="itemText"></param>
//        /// <returns>
//        /// validateString
//        /// </returns>
//        public static string GetValidatorString(string errorMessage, string itemText)
//        {
//            return Resources.GetString(errorMessage.Substring(errorMessage.IndexOf(FilePaths.semicolon) + 1)).Replace(FilePaths.charSpecial, itemText);
//        }

//        /// <summary>
//        /// show MessageBox
//        /// </summary>
//        /// <param name="keyError"></param>
//        /// <param name="keyTitle"></param>
//        /// <param name="button"></param>
//        /// <param name="icon"></param>
//        /// <returns>
//        /// dialogResult
//        /// </returns>
//        public static DialogResult ShowMessageBox(string keyError, string keyTitle, MessageBoxButtons button, MessageBoxIcon icon)
//        {
//            return MessageBox.Show(Resources.GetString(keyError, ResourceSetting.CultureInfos), Resources.GetString(keyTitle, ResourceSetting.CultureInfos), button, icon);
//        }
//    }
//}
