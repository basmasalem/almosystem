﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Repositories
{
  public  interface IRepositoryWrapper
    {
         ISubscribeRequestRepository SubscribeRequestRepository { get; }
         ISettingsRepository SettingsRepository { get; }
         IUserRepository UserRepository { get; }
         IProblemRepository ProblemRepository { get; }
         IHelpRepository HelpRepository { get; }
         INotificationRepository NotificationRepository { get; }
         ICourseRepository CourseRepository { get; }
    }
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private  ISubscribeRequestRepository _SubscribeRequestRepository;
        private  ISettingsRepository _SettingsRepository;
        private  IUserRepository _userRepository;
        private  IProblemRepository _ProblemRepository;
        private  IHelpRepository _HelpRepository;
        private  INotificationRepository _NotificationRepository;
        private  ICourseRepository _CourseRepository;
        public   AppDBContext _appDBContext;
        public RepositoryWrapper(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public ISubscribeRequestRepository SubscribeRequestRepository
        {
            get
            {
                if (_SubscribeRequestRepository == null)
                {
                    _SubscribeRequestRepository = new SubscribeRequestRepository(_appDBContext);
                }
                return _SubscribeRequestRepository;
            }
        }
        public ISettingsRepository SettingsRepository
        {
            get
            {
                if (_SettingsRepository == null)
                {
                    _SettingsRepository = new SettingsRepository(_appDBContext);
                }
                return _SettingsRepository;
            }
        }
        public IProblemRepository ProblemRepository
        {
            get
            {
                if (_ProblemRepository == null)
                {
                    _ProblemRepository = new ProblemRepository(_appDBContext);
                }
                return _ProblemRepository;
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_appDBContext);
                }
                return _userRepository;
            }
        }
        public ICourseRepository CourseRepository
        {
            get
            {
                if (_CourseRepository == null)
                {
                    _CourseRepository = new CourseRepository(_appDBContext);
                }
                return _CourseRepository;
            }
        }
        public IHelpRepository HelpRepository
        {
            get
            {
                if (_HelpRepository == null)
                {
                    _HelpRepository = new HelpRepository(_appDBContext);
                }
                return _HelpRepository;
            }
        }
        public INotificationRepository NotificationRepository
        {
            get
            {
                if (_NotificationRepository == null)
                {
                    _NotificationRepository = new NotificationRepository(_appDBContext);
                }
                return _NotificationRepository;
            }
        }
    }
}
