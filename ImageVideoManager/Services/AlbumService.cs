using ImageVideoManager.Data;
using Microsoft.EntityFrameworkCore;
using Telerik.Blazor.Components;
using static Azure.Core.HttpHeader;

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
         *      GetAlbumNames()
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

        //------------------------------------------------------------
        //--- Get Album Names
        public List<string> GetAlbumNames()
        {
            List<string> alnames = _dbx.Albums.Select(x => x.AlbumName).ToList();
            return alnames;
        }

        /************************************************************************
         * Functions for Tag
         *      GetTagData()
         *      AddOrUpdateTag()
         *      GetTagNames()
        ************************************************************************/
        //------------------------------------------------------------
        //--- Retrieve Tag
        public List<BaseTag> GetTagData()
        {
            List<BaseTag> tags = _dbx.Tags.ToList();
            return tags;
        }

        //------------------------------------------------------------
        //--- Add or Update Tag
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

        //------------------------------------------------------------
        //--- Get Tag Lists
        public List<string> GetTagNames()
        {
            List<string> tgnames = _dbx.Tags.Select(x => x.TagName).ToList();
            return tgnames;
        }

        /************************************************************************
         * Functions for Media
         *      GetTagData()
         *      AddOrUpdateTag()
         *      GetTagNames()
        ************************************************************************/

        //------------------------------------------------------------
        //--- Add Media To DB : 중복 체크 ==> AlbumName & MediaFileName
        //    1) MediaTable
        //    2) MediaTagTable
        public string AddOrUpdateMedia(MediaDto mdDto, FileSelectFileInfo fi, string strId, List<string> listTags, string targetDir)
        {
            //--- Check if file exist
            var oldmd = _dbx.Medias.Where(x => x.FileName == fi.Name).ToList();

            //--- Update
            if (oldmd != null && oldmd.Count > 0)
            {

            }
            //--- Add
            else
            {
                Media media = new Media();

                media.FileName = fi.Name;
                media.FilePath = targetDir;        // root/album명
                media.FileSize = (int) fi.Size;

                media.AlbumID = _dbx.Albums.Where(x => x.AlbumName == mdDto.AlbumName).Select(n => n.AlbumID).FirstOrDefault();
                media.PictureDate = mdDto.PictureDate.ToString();
                media.Place = mdDto.Place;
                media.PeopleRelation = mdDto.PeopleRelation;
                media.DateUploaded = DateTime.Now;
                media.UserID = strId;
                media.MediaType = "image";
                media.Reserved1 = String.Join(", ", listTags.ToArray());

                _dbx.Medias.Add(media);
            }
            int no = _dbx.SaveChanges();

            return no.ToString() + " Added";
        }
    }

}
