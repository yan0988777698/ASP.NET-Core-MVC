namespace projCoreMVC.Models
{
    public class CRoomWrap
    {
        TRoom _room;
        public CRoomWrap()
        {
            if (_room == null)
            {
                _room = new TRoom();
            }
        }
        public TRoom room
        {
            get { return _room; }
            set { _room = value; }
        } 
        public int Fid {
            get { return _room.Fid; }
            set { _room.Fid = value; }
        }

        public string? FName {
            get { return _room.FName; }
            set { _room.FName = value; }
        }

        public decimal? FPrice {
            get { return _room.FPrice; }
            set { _room.FPrice = value; }
        }

        public int? FAmount {
            get { return _room.FAmount; }
            set { _room.FAmount = value; }
        }

        public string? FDescription {
            get { return _room.FDescription; }
            set { _room.FDescription = value; }
        }

        public string? FImagePath {
            get { return _room.FImagePath; }
            set { _room.FImagePath = value; }
        }
        public IFormFile? photo { get;set; }
    }
}
