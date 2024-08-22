using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diploma

{
    public partial class genres
    {
        public genres(string genrename)
        {

            this.genrename = genrename;
          

            OnCreated();
        }
        public override string ToString()
        {
            return $" {this.id}. {genrename}   \r\n";
        }


    }


    public partial class webbookstore
    {
        public webbookstore(string bookname, string price, string descrip, string genre,  int stock, DateTime releasedate)
        {

            this.bookname = bookname;
            this.price = price;
            this.descrip = descrip;
            this.genre = genre;
		
            this.stock = stock;
            this.releasedate = releasedate;
           
            OnCreated();
        }
        public override string ToString()
        {
            return $" {this.id}. {bookname}   {price}   {price}  {descrip}  {genre}  {stock} {releasedate}   \r\n";
        }


    }


    public partial class orders
	{
		public orders( int ordernumber, string bookname, string price, string customername, string orderadress , string paymentmethod,string deliverymethod,string orderstatus)
		{
			
			this.ordernumber = ordernumber;
			this.bookname = bookname;
			this.price = price;
			this.customername = customername;
			this.orderadress = orderadress;
            this.paymentmethod = paymentmethod;
            this.deliverymethod = deliverymethod;
            this.orderstatus = orderstatus;
            OnCreated();
		}
		public override string ToString()
		{
			return $" {this.id}. {ordernumber}   {bookname}   {price}  {customername}  {orderadress} {paymentmethod} {deliverymethod} {orderstatus}  \r\n";
		}


	}
	public partial class completeorders
	{
		public completeorders( string bookname, string price, DateTime selltime)
		{

			
			this.bookname = bookname;
			this.price = price;
			this.selltime = selltime;
		
			OnCreated();
		}
		public override string ToString()
		{
			return $" {this.id}.  {bookname}   {price}  {selltime} \r\n";
		}


	}
}
