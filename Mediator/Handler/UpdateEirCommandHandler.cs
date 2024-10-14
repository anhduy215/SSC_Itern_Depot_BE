using DepotBackEnd.Entities;
using DepotBackEnd.Mediator.Request;
using DepotBackEnd.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
namespace DepotBackEnd.Mediator.Handler
{
    public class UpdateEirCommandHandler : IRequestHandler<UpdateEirCommand, Eir>
    {
        private readonly EirRepository _eirRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateEirCommandHandler(EirRepository eirRepository, IHttpContextAccessor httpContextAccessor)
        {
            _eirRepository = eirRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Eir> Handle(UpdateEirCommand request, CancellationToken cancellationToken)
        {
            // Lấy Eir hiện tại dựa trên EirNumber
            var eir = await _eirRepository.GetEirByIdAsync(request.EirNumber);
            var eirUpdate = request.EirDTO;

            // Kiểm tra và xử lý approvements
            if (eirUpdate.Approvements != "Approve" && eirUpdate.Approvements != "Reject")
            {
                throw new ArgumentException("Approvements phải là 'Approve' hoặc 'Reject'.");
            }
            if (eir.Approvements != null)
            {
                throw new ArgumentException("đã được kiểm duyệt");
            }
            // Cập nhật các thuộc tính không null từ DTO, null thì k update
            if (request.EirDTO != null)
            {
                eir.Approvements = eirUpdate.Approvements;
                var userIdFromSession = _httpContextAccessor.HttpContext?.Session.GetInt32("UserID");
                //check user trong session
                if (!userIdFromSession.HasValue)
                {
                    throw new UnauthorizedAccessException("UserID not exist in session.");
                }
                eir.UserID = userIdFromSession.Value;
            }
            // Lưu thay đổi vào cơ sở dữ liệu
            return await _eirRepository.UpdateAsync(eir);
        }
    }

}