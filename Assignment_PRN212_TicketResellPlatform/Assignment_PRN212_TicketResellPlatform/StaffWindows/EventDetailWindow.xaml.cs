using BusinessObject;
using Microsoft.Win32;
using Service.EventService;
using Service.User;
using Service.Utils;
using Service.Utils.NhatTruong;
using Service.Utils.TienThuan;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Assignment_PRN212_TicketResellPlatform.StaffWindows
{
    /// <summary>
    /// Interaction logic for EventDetailWindow.xaml
    /// </summary>
    public partial class EventDetailWindow : Window
    {
        private readonly IEventService eventService;
        private Event Event;
        private ManageEventWindow manageEventWindow;
        private ACTION action;

        public EventDetailWindow()
        {
            InitializeComponent();
            eventService = new EventService();
        }

        public EventDetailWindow(Event Event, ACTION action, ManageEventWindow manageEventWindow)
        {
            InitializeComponent();
            eventService = new EventService();
            this.Event = Event;
            this.manageEventWindow = manageEventWindow;
            this.action = action;
            switch (action)
            {
                case ACTION.ADD:
                    CaseAdd();
                    break;
                case ACTION.DEATAIL:
                    CaseDetail();
                    break;
                case ACTION.UPDATE:
                    CaseUpdate();
                    break;
            }
        }

        //Case action
        private void CaseAdd()
        {
            btnAction.Content = "Create";
            txtEventId.Visibility = Visibility.Collapsed;
        }

        private void CaseUpdate()
        {
            btnAction.Content = "Update";
            txtEventId.IsEnabled = false;
            //btnChooseImage.Visibility = Visibility.Collapsed;
            AddInfoEvent();
        }

        private void CaseDetail()
        {
            DisableAttribute();
            btnAction.Visibility = Visibility.Collapsed;
            AddInfoEvent();
        }

        //--------------

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            if (action == ACTION.ADD) 
            {
                CreateEvent();
                manageEventWindow.LoadData();
                this.Close();
            }else if (action == ACTION.UPDATE)
            {
                UpdateEvent();
            }    
        }

        private void CreateEvent()
        {
            Event addEvent = new Event();
            addEvent.Name = txtEventName.Text;
            addEvent.Detail = txtEventDetail.Text;
            addEvent.IsDeleted = false;
            addEvent.StartDate = dpStartDate.Value.HasValue ? dpStartDate.Value.Value : DateTime.MinValue;
            addEvent.EndDate = dpEndDate.Value.HasValue ? dpEndDate.Value.Value : DateTime.MinValue;
            addEvent.Image = GetFileName();

            eventService.CreateEvent(addEvent);
        }

        private void UpdateEvent()
        {
            Event addEvent = new Event();
            addEvent.Name = txtEventName.Text;
            addEvent.Detail = txtEventDetail.Text;
            addEvent.IsDeleted = false;
            addEvent.StartDate = dpStartDate.Value.HasValue ? dpStartDate.Value.Value : DateTime.MinValue;
            addEvent.EndDate = dpEndDate.Value.HasValue ? dpEndDate.Value.Value : DateTime.MinValue;
            addEvent.Image = GetFileName();

            eventService.UpdateEvent(addEvent);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddInfoEvent()
        {
            if (Event != null)
            {
                Uri uri = new Uri(LocalPathSetting.EventImagePath+ Event.Image, UriKind.Absolute);
                txtEventId.Text = Event.Id.ToString();
                txtEventName.Text = Event.Name;
                txtEventDetail.Text = Event.Detail;
                dpStartDate.Value = Event.StartDate;
                dpEndDate.Value = Event.EndDate;
                imgEventImage.Source = new BitmapImage(uri);
            }
        }

        private void DisableAttribute()
        {
            txtEventId.IsEnabled = false;
            txtEventDetail.IsEnabled = false;
            txtEventId.IsEnabled = false;
            txtEventName.IsEnabled = false;
            dpEndDate.IsEnabled = false;
            dpStartDate.IsEnabled = false;
        }

        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                try
                {
                    string fullFilename = fileDialog.FileName;
                    imgEventImage.Source = new BitmapImage(new Uri(fullFilename, UriKind.Absolute));
                    FileInfo fileInfo = new FileInfo(fullFilename);
                    string filename = System.IO.Path.GetFileName(fullFilename);
                    fileInfo.CopyTo(LocalPathSetting.EventImagePath + filename);
                    
                    //ShowInfoMessageBox("Cập nhật ảnh đại diện thành công!");
                }
                catch (Exception ex)
                {
                    //ShowErrorMessageBox("Cập nhật ảnh đại diện không thành công!");
                }
            }
        }

        private string GetFileName()
        {
            if (imgEventImage.Source is BitmapImage bitmapImage)
            {
                string fullPath = bitmapImage.UriSource.AbsoluteUri;
                return System.IO.Path.GetFileName(fullPath);
            }
            return null;
        }
    }
}
