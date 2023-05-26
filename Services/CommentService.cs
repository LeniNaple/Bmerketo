using Bmerketo.Contexts;
using Bmerketo.Models.Entities;
using Bmerketo.Models.Identity;
using Bmerketo.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Services
{
    public class CommentService
    {
        private readonly CommentContext _commentContext;

        public CommentService(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        //Saves a comment and their info
        public async Task<bool> RegisterCommentAsync(ContactFormViewModel viewModel)
        {
            try
            {
                //Gets info from contact form
                ContactComment _contactComment = viewModel;
                CommentUser _commentUser = viewModel;

                if (_contactComment.SaveEmail == false)
                {
                    // If they dont want info saved, overwrites info with "Unknown"
                    _contactComment.CommentInfo = new CommentUser
                    {
                        Email = "Unknown",
                        Alias = "Unknown",
                        PhoneNumber = "Unknown",
                        Company = "Unknown",
                    };

                    // Checks if there already exists incognito info in db
                    var _incognitoUser = await _commentContext.CommentInfos.FirstOrDefaultAsync(x => x.Email == _contactComment.CommentInfo.Email && x.Alias == _contactComment.CommentInfo.Alias);

                    // Sets old incognito info to new comment
                    if (_incognitoUser != null)
                    {
                        _contactComment.CommentId = _incognitoUser.Id;
                        _contactComment.CommentInfo = _incognitoUser;
                    }

                }
                else
                {
                    //Checks if there is info for a person already
                    var _commentInfo = await _commentContext.CommentInfos.FirstOrDefaultAsync(x => x.Email == viewModel.Email && x.Alias == viewModel.Name);
                    if (_commentInfo == null)
                    {
                        //Sets new data for a persons info
                        _contactComment.CommentInfo = new CommentUser
                        {
                            Email = _commentUser.Email,
                            Alias = _commentUser.Alias,
                            PhoneNumber = _commentUser.PhoneNumber,
                            Company = _commentUser.Company,
                        };

                    }
                    else
                    {
                        //Sets old info to comment from db, (the person has commented before)
                        _contactComment.CommentId = _commentInfo.Id;
                        _contactComment.CommentInfo = _commentInfo;

                    }
                }
               

                //Adds info to Comment, and adds new row to db
                _commentContext.Add(new ContactComment
                {
                    Comment = _contactComment.Comment,
                    SaveEmail = _contactComment.SaveEmail,
                    CommentId = _contactComment.CommentInfo.Id,
                    CommentInfo = _contactComment.CommentInfo,
                });

                // Saves changes to user
                await _commentContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }


        // THIS ONE SAVES THE INFO TWICE!!!
        //public async Task<bool> RegisterCommentAsync(ContactFormViewModel viewModel)
        //{
        //    try
        //    {
        //        ContactComment _contactComment = viewModel;
        //        CommentUser _commentUser = viewModel;


        //        // See if the email wants to be saved?
        //        if (_contactComment.SaveEmail == true)
        //        {
        //            // Sees whether or not there is a user to the comments already
        //            var _commentInfo = await _commentContext.CommentInfos.FirstOrDefaultAsync(x => x.Email == viewModel.Email && x.Alias == viewModel.Name);
        //            if (_commentInfo == null)
        //            {
        //                // Creates new user
        //                _contactComment.CommentInfo = new CommentUser
        //                {
        //                    Email = _commentUser.Email,
        //                    Alias = _commentUser.Alias,
        //                    PhoneNumber = _commentUser.PhoneNumber,
        //                    Company = _commentUser.Company,
        //                };
        //                _commentContext.Add(_commentUser);

        //                // Saves changes to user
        //                await _commentContext.SaveChangesAsync();

        //                _contactComment.CommentId = _commentUser.Id;

        //            }
        //            else
        //            {
        //                //Sets existing user to new comment
        //                _contactComment.CommentId = _commentInfo.Id;
        //                _contactComment.CommentInfo = _commentInfo;

        //            }
        //        }
        //        // Set value to "Unidentified", since they dont want info saved
        //        else
        //        {
        //            _contactComment.CommentInfo = new CommentUser
        //            {
        //                //Need to add filter funtction so it doesnt add ontop all the time 
        //                Email = "Unknown",
        //                Alias = "Unknown",
        //                PhoneNumber = "Unknown",
        //                Company = "Unknown",
        //            };
        //            var _commentInfo = await _commentContext.CommentInfos.FirstOrDefaultAsync(x => x.Email == viewModel.Email && x.Alias == viewModel.Name);
        //            if (_commentInfo != null)
        //            {
        //                _contactComment.CommentId = _commentInfo.Id;
        //                _contactComment.CommentInfo = _commentInfo;
        //            }
        //        }

        //        //Creates new comment
        //        _commentContext.Add(new ContactComment
        //        {
        //            Comment = _contactComment.Comment,
        //            SaveEmail = _contactComment.SaveEmail,
        //            CommentId = _commentUser.Id,
        //            CommentInfo = _contactComment.CommentInfo,
        //        });

        //        // Saves changes to user
        //        await _commentContext.SaveChangesAsync();


        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}

    }
}
