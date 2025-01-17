﻿using Core.Api.ViewModels;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Service
{
    public interface ISubscribeRequestService
    {
        public List<SubscribeRequest> GetAllSubscribeRequests();
        public List<SubscribeRequest> SearchInSubscribeRequests(string Name,string Email, DateTime? fromDate, DateTime? ToDate);
        public SubscribeRequest GetSubscribeRequestData(int Id);
        public SubscribeRequestVM LastUserSubscribeRequestDate(int UserId);
        public void DeleteSubscribeRequest(SubscribeRequest Model);
        public void UpdateSubscribeRequest(SubscribeRequest Model);
        public SubscribeRequest AddSubscribeRequest(SubscribeRequest Model);
        public SubscribeRequest CheckRequest(int userId, DateTime? fromDate, DateTime? ToDate);



    }
    public class SubscribeRequestService : ISubscribeRequestService
    {
        private readonly ISubscribeRequestRepository _SubscribeRequestRepository;
        public SubscribeRequestService(ISubscribeRequestRepository SubscribeRequestRepository)
        {
            _SubscribeRequestRepository = SubscribeRequestRepository;
        }
        public SubscribeRequest AddSubscribeRequest(SubscribeRequest Model)
        {
            return _SubscribeRequestRepository.Add(Model);
        }

        public void DeleteSubscribeRequest(SubscribeRequest SubscribeRequest)
        {
            _SubscribeRequestRepository.Delete(SubscribeRequest);
        }

        public List<SubscribeRequest> GetAllSubscribeRequests()
        {
           return _SubscribeRequestRepository.List().ToList();
        }

        public SubscribeRequest GetSubscribeRequestData(int Id)
        {
            return _SubscribeRequestRepository.Find(Id);
        }

        public SubscribeRequestVM LastUserSubscribeRequestDate(int UserId)
        {
            return _SubscribeRequestRepository.List().Where(u => u.UserId == UserId && u.IsDeleted!=true).ToList().Select(n=>new SubscribeRequestVM() { 
               SubscribeRequestId=n.SubscribeRequestId,
                Cost=n.Cost??0,
                DateCreated=n.DateCreated,
                FromDate=n.FromDate,
                ToDate=n.ToDate,
                Period=n.Period,
                IsActive=n.IsActive
 
            }).LastOrDefault();
        }

        public List<SubscribeRequest> SearchInSubscribeRequests(string Name, string Email, DateTime? fromDate, DateTime? ToDate)
        {
            return _SubscribeRequestRepository.List().Where(u=>(string.IsNullOrEmpty(Name)|| u.UserCreated.Name.Contains(Name))
            &&(string.IsNullOrEmpty(Email) || u.UserCreated.Email==Email) 
            && ((!fromDate.HasValue|| u.FromDate.Value.Date >= fromDate.Value.Date ) && (!ToDate.HasValue|| ToDate.Value.Date <= u.ToDate.Value.Date))).ToList();
        }
        public SubscribeRequest CheckRequest(int userId,DateTime? fromDate,DateTime? ToDate)
        {
            return _SubscribeRequestRepository.List().FirstOrDefault(r=>r.UserId==userId && r.IsActive==true && r.FromDate.Value.Date==fromDate.Value.Date && ToDate.Value.Date==r.ToDate.Value.Date);
        }
        public void UpdateSubscribeRequest( SubscribeRequest Model)
        {
             _SubscribeRequestRepository.Update(Model);
        }

 
    }
}
