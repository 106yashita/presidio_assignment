
using ModelClassLib;
using StoreBLLibrary;

namespace VideoStoreApp
{
    internal class Program
    {
        VideoBL VideoBL = new VideoBL();
        CustomerBL CustomerBL = new CustomerBL();
        RentalBL RentalBL = new RentalBL();
        public void FirstInteraction()
        {
            while (true)
            {
                Console.WriteLine("****************************************");
                Console.WriteLine("Welcome to the Video Store Management System");
                Console.WriteLine("1. Video Catalog\r\n2. Customer Management\r\n" +
                    "3. Rental Process\r\n4. Return Process\r\n5. Exit");
                Console.WriteLine("please enter your choice :");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        VideoCatalog();
                        break;
                    case 2:
                        CustomerManagement();
                        break;
                    case 3:
                        RentalProcess();
                        break;
                    case 4:
                        ReturnProcess();
                        break;
                    case 5:
                        Console.WriteLine("Thank You !!!!! Bye !!!");
                        return;
                    default: break;
                }
            }
        }

        private void ReturnProcess()
        {
            while (true)
            {
                Console.WriteLine("################################");
                Console.WriteLine("Return Process");
                Console.WriteLine("1. Return a Video\r\n2. Go Back");
                Console.WriteLine("Please enter your choice :");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ReturnVideo();
                        break;
                    case 2:
                        Console.WriteLine("Going back !!!!!");
                        return;
                    default:
                        Console.WriteLine("wrong choice");
                        break;
                }
            }
        }

        private void ReturnVideo()
        {
            Console.WriteLine("Please enter your customer id:");
            int id=int.Parse(Console.ReadLine());
            List<Rental> rentals=RentalBL.GetRentalsForCustomer(id);
            Console.WriteLine("list of videos that you have rented:");
            foreach (Rental rental in rentals)
            {
                Video video = VideoBL.GetVideoById(rental.Video_id);
                Console.WriteLine(rental.Rental_id + " " + video.Title);
            }
            Console.WriteLine("enter the rental id that you want to return:");
            int rentalid = int.Parse(Console.ReadLine());
            Rental rental1=RentalBL.ReturnRentVideo(rentalid);
            //CustomerBL.RemoveRentedVideoFromCustomer(id, rental1.Video_id);
            Video video1 = VideoBL.GetVideoById(rental1.Video_id);
            double price=rental1.Late_fee + video1.RentalPrice;
            Console.WriteLine("Your total amount to pay is: " + price);
        }
        
        private void RentalProcess()
        {
            while (true)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Rental Process");
                Console.WriteLine("1. Browse Videos\r\n2. Rent a Video\r\n" +
                    "3.total rental fee for a customer \r\n4. Go Back");
                Console.WriteLine("Please enter your choice :");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        BrowseVideos();
                        break;
                    case 2:
                        RentVideo();
                        break;
                    case 3:
                        TotalCustomerPrice();
                        break;
                    case 4:
                        Console.WriteLine("Going back !!!!!");
                        return;
                    default:
                        Console.WriteLine("wrong choice");
                        break;

                }
            }
        }

        private void TotalCustomerPrice()
        {
            Console.WriteLine("please enter your customer id :");
            int id=int.Parse(Console.ReadLine());   
            double price=RentalBL.CalculateTotalRentalFeesForCustomer(id);
            Console.WriteLine("Your total amount is : " + price);
        }

        private void RentVideo()
        {
            Rental rental = new Rental();
            Console.WriteLine("enter your customer id:");
            int customer_id=int.Parse(Console.ReadLine());
            Console.WriteLine("enter the video id:");
            int video_id=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the due date:");
            DateTime duedate=DateTime.Parse(Console.ReadLine());
            rental.Due_date= duedate;
            rental.Customer_id= customer_id;
            rental.Video_id= video_id;
            int id=RentalBL.AddRentVideo(rental);
            //VideoBL.UpdateAvailabilityStatus(video_id);
            //CustomerBL.AddRentedVideoToCustomer(customer_id, video_id);
            Console.WriteLine("Added a Rental Video by id :" + id);
        }

        private void BrowseVideos()
        {
            List<Video> videos = VideoBL.GetAllVideos();
            foreach (Video video in videos)
            {
                Console.WriteLine(video.VideoId+" " +video.Title + "  " + video.Genre + " " + video.RentalPrice);
            }
        }

        public void CustomerManagement()
        {
            while (true)
            {
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                Console.WriteLine("Customer Management:");
                Console.WriteLine("1. View All Customers\r\n2. Search Customers\r\n" +
                    "3. Add New Customer\r\n4. Go Back");
                Console.WriteLine("Please enter your choice :");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ViewAllCustomers();
                        break;
                    case 2:
                        SearchCustomer();
                        break;
                    case 3:
                        AddNewCustomer();
                        break;
                    case 4:
                        Console.WriteLine("Going Back !!!!");
                        return;
                    default:
                        Console.WriteLine("wrong choice");
                        break;
                }

            }
        }

        private void AddNewCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("enter your emailId:");
            string email = Console.ReadLine();
            customer.CustomerEmail = email;
            customer.CustomerName = name;
            int id = CustomerBL.AddCustomer(customer);
            Console.WriteLine("Customer added with id : " + id);
        }

        private void SearchCustomer()
        {
            Console.WriteLine("enter customer id :");
            int id = int.Parse(Console.ReadLine());
            Customer customer = CustomerBL.GetCustomerById(id);
            Console.WriteLine(customer.CustomerName);
        }

        private void ViewAllCustomers()
        {
            List<Customer> customers = CustomerBL.GetAllCustomers();
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.CustomerName);
            }
        }

        public void VideoCatalog()
        {
            while (true)
            {
                Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
                Console.WriteLine("Video Catalog:");
                Console.WriteLine("1. View All Videos\r\n2. Search Videos\r\n3. Add New Video\r\n" +
                    "4. Remove Video\r\n5.Search by Availability \r\n6. Go Back");
                Console.WriteLine("Please enter your choice :");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ViewAllVideos();
                        break;
                    case 2:
                        SearchVideos();
                        break;
                    case 3:
                        AddVideo();
                        break;
                    case 4:
                        RemoveVideo();
                        break;
                    case 5:
                        SearchByAvailabilty();
                        break;
                    case 6:
                        Console.WriteLine("going back");
                        return;
                    default:
                        Console.WriteLine("wrong choice");
                        break;
                }
            }
        }

        private void SearchByAvailabilty()
        {
            List<Video> videos = VideoBL.SearchAvailableVideos();
            Console.WriteLine("Videos that are available:");
            foreach (Video video in videos)
            {
                Console.WriteLine(video.VideoId + " " +  video.Title);
            }
        }

        private void RemoveVideo()
        {
            Console.WriteLine("Enter the video_id:");
            int id = int.Parse(Console.ReadLine());
            Video video = VideoBL.RemoveVideo(id);
            Console.WriteLine("Remove video :" + video.Title);
        }

        private void AddVideo()
        {
            Video video = new Video();
            Console.WriteLine("Enter the title :");
            string title = Console.ReadLine();
            video.Title = title;
            Console.WriteLine("Enter the genre :");
            string genre = Console.ReadLine();
            video.Genre = genre;
            Console.WriteLine("Enter the rental price :");
            int price = int.Parse(Console.ReadLine());
            video.RentalPrice = price;
            int id = VideoBL.AddVideo(video);
            Console.WriteLine("video added by id :" + id);
        }

        public void SearchVideos()
        {
            Console.WriteLine("Please enter the genre:");
            string genre = Console.ReadLine();
            List<Video> videos = VideoBL.GetVideosByGenre(genre);
            foreach (Video video in videos)
            {
                Console.WriteLine(video.Title);
            }
        }

        public void ViewAllVideos()
        {
            List<Video> videos = VideoBL.GetAllVideos();
            foreach (Video v in videos)
            {
                Console.WriteLine(v.Title);
            }
            }

            static void Main(string[] args)
            {
                Program program = new Program();
                program.FirstInteraction();
            }
        }
    }

