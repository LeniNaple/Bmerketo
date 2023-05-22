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


        // Save comment to db
        // See if the email wants to be saved?
        // If not set value to "Unidentified"
        // See if there is a user already
        // if there is, then load. If not then save
        // 

        public async Task<bool> RegisterCommentAsync(ContactFormViewModel viewModel)
        {
            try
            {
                ContactComment _contactComment = viewModel;
                CommentUser _commentUser = viewModel;

                if (_contactComment.SaveEmail == true)
                {
                    var _commentInfo = await _commentContext.CommentInfos.FirstOrDefaultAsync(x => x.Email == viewModel.Email && x.Alias == viewModel.Name);
                    if (_commentInfo == null)
                    {
                        _contactComment.CommentInfo = new CommentUser
                        {
                            Email = _commentUser.Email,
                            Alias = _commentUser.Alias,
                            PhoneNumber = _commentUser.PhoneNumber,
                            Company = _commentUser.Company,
                        };
                        _commentContext.Add(_commentUser);
                        await _commentContext.SaveChangesAsync();

                        _contactComment.CommentId = _commentUser.Id;

                    }
                    else
                    {
                        _contactComment.CommentId = _commentInfo.Id;
                        _contactComment.CommentInfo = _commentInfo;

                    }
                }
                else
                {
                    _contactComment.CommentInfo = new CommentUser
                    {

                        //Need to add filter funtction so it doesnt add ontop all the time 
                        Email = "Unknown",
                        Alias = "Unknown",
                        PhoneNumber = "Unknown",
                        Company = "Unknown",
                    };
                }

                _commentContext.Add(new ContactComment
                {
                    Comment = _contactComment.Comment,
                    SaveEmail = _contactComment.SaveEmail,
                    CommentId = _commentUser.Id,
                    CommentInfo = _contactComment.CommentInfo,
                });


                await _commentContext.SaveChangesAsync();


                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
