using ImageVideoManager.Data;
using Microsoft.EntityFrameworkCore;

namespace ImageVideoManager.Services
{


    public class AlbumService
    {
        private readonly AlbumDbContext _dbx;                // Album DB
        private readonly ApplicationDbContext _dbxUser;      // User DB


        //------------------------------------------------------------
        public AlbumService(AlbumDbContext dbContext, ApplicationDbContext dbContextUser)
        {
            _dbx = dbContext;
            _dbxUser = dbContextUser;
        }


        /************************************************************************
         * Functions for Album
         *      GetAlbumData()
         *      AddOrUpdateAlbum()
         ************************************************************************/

        //------------------------------------------------------------
        //--- Retrieve Album
        public List<Album> GetAlbumData()
        {
            List<Album> albums = _dbx.Albums.ToList();
            return albums;
        }

        //------------------------------------------------------------
        //--- Add or Update Album
        public string AddOrUpdateAlbum(AlbumTagDto atDto, string strId)
        {
            Album album = new Album();

            album.AlbumName = atDto.AlbumName;
            album.Description = atDto.Description;
            album.UserID = strId;
            album.CreateAt = DateTime.Now;

            _dbx.Albums.Add(album);
            
            int no = _dbx.SaveChanges();

            return no.ToString() + " Added";
        }

        /************************************************************************
         * Functions for Album
         *      GetAlbumData()
         *      AddOrUpdateAlbum()
        ************************************************************************/
        //------------------------------------------------------------
        //--- Retrieve Album
        public List<BaseTag> GetTagData()
        {
            List<BaseTag> tags = _dbx.Tags.ToList();
            return tags;
        }

        //------------------------------------------------------------
        //--- Add or Update Album
        public string AddOrUpdateTag(string strTag)
        {
            if (strTag.Length < 1)
                return "There is no Tag Name";

            BaseTag tag = new BaseTag();

            tag.TagName = strTag;

            _dbx.Tags.Add(tag);

            int no = _dbx.SaveChanges();

            return no.ToString() + " Added";
        }


    }

}
