using System.Windows;
using BusinessObject;
using Service.Ticket;
using Service.TicketService;


namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    public partial class ViewTicketDetailWindow : Window
    {
        private Ticket choosenTicket;

        private ITicketService ticketService = new TicketService();

        private IGenericTicketService genericTicketService = new GenericTicketService();    

        private ICategoryService categoryService = new CategoryService();

        public ViewTicketDetailWindow(long ticketId)
        {
            InitializeComponent();
            InitDataWindow(ticketId);
        }

        public void InitDataWindow(long ticketId)
        {
            //this.choosenTicket = ticketService.GetTicketById(ticketId);
            //GenericTicket genericTicket = genericTicketService.FindGenericTicketById((long)choosenTicket.GenericTicketId);
            //Category category = 
            //ticketNameLabel.Content = ticketNameLabel.Content + genericTicket.TicketName;
        }
    }
}
