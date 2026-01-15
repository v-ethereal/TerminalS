using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Arsis.RentalSystem.Core.Domain
{
	public class ServiceInformationExt
	{
		#region Fields

		private int id;
		private string name;
		private string description;
		private decimal currentPrice;
		private bool isRental;
		private bool isActive;
		private byte[] picture;
		private string oneSCode;
		private bool isParkingPerHour;
		private bool isParkingWithoutTime;
		private bool isOther;
	    private bool usePlaceNumber;

		#endregion

		#region Constructors

		public ServiceInformationExt(int id, string name, bool isRental, bool isActive, string description, byte[] picture, string oneSCode, decimal? currentPrice)
		{
			this.id = id;
			this.name = name;
			this.isRental = isRental;
			this.isActive = isActive;
			this.description = description;
			this.picture = picture;
			this.oneSCode = oneSCode;
			this.currentPrice = currentPrice ?? 0;
		}

		public ServiceInformationExt(int id, string name, bool isRental, bool isActive, bool isParkingPerHour, bool isParkingWithoutTime, bool isOther, string description, byte[] picture, string oneSCode, decimal? currentPrice) : this(id, name, isRental, isActive, description, picture, oneSCode, currentPrice)
		{
			this.isParkingPerHour = isParkingPerHour;
			this.isParkingWithoutTime = isParkingWithoutTime;
			this.isOther = isOther;
		}

        public ServiceInformationExt(int id, string name, bool isRental, bool isActive, bool isParkingPerHour, bool isParkingWithoutTime, bool isOther, string description, byte[] picture, string oneSCode, bool usePlaceNumber, decimal? currentPrice)
            : this(id, name, isRental, isActive, isParkingPerHour, isParkingWithoutTime, isOther, description, picture, oneSCode, currentPrice)
        {
            this.usePlaceNumber = usePlaceNumber;
        }

		#endregion

		#region Properties

        public bool IsOther
        {
            get { return isOther; }
            set { isOther = value; }
        }

        public bool UsePlaceNumber
        {
            get { return usePlaceNumber; }
            set { usePlaceNumber = value; }
        }

        public bool IsParkingWithoutTime
		{
			get { return isParkingWithoutTime; }
			set { isParkingWithoutTime = value; }
		}

		public bool IsParkingPerHour
		{
			get { return isParkingPerHour; }
			set { isParkingPerHour = value; }
		}

		public string OneSCode
		{
			get { return oneSCode; }
			set { oneSCode = value; }
		}

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		public decimal CurrentPrice
		{
			get { return currentPrice; }
			set { currentPrice = value; }
		}

		public bool IsRental
		{
			get { return isRental; }
			set { isRental = value; }
		}

		public bool IsActive
		{
			get { return isActive; }
			set { isActive = value; }
		}

		public byte[] Picture
		{
			get { return picture; }
			set { picture = value; }
		}

		public byte[] PictureThumbnail
		{
			get
			{
				byte[] buffer = null;
				if (Picture != null)
				{
					using (MemoryStream stream = new MemoryStream(Picture))
					{
						Image image = Image.FromStream(stream);
						Image.GetThumbnailImageAbort myCallback = ThumbnailCallback;

						Image thumbImage = image.GetThumbnailImage(16, 16, myCallback, IntPtr.Zero);

						using (MemoryStream memoryStream = new MemoryStream())
						{
							thumbImage.Save(memoryStream, ImageFormat.Png);
							stream.Flush();
							memoryStream.Seek(0, SeekOrigin.Begin);
							buffer = new byte[memoryStream.Length];
							memoryStream.Read(buffer, 0, buffer.Length);
						}
					}
				}
				return buffer;
			}

		}

		private bool ThumbnailCallback()
		{
			return false;
		}

		#endregion
	}
}