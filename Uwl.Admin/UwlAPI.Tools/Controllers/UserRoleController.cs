﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uwl.Data.Model.Result;
using Uwl.Data.Server.UserServices;

namespace UwlAPI.Tools.Controllers
{
    /// <summary>
    /// 用户角色控制器
    /// </summary>
    [Route("api/UserRoles")]
    [ApiController]
    public class UserRoleController : Controller
    {
        private readonly IUserRoleServer _userRoleServer;
        /// <summary>
        /// 注入用户角色服务层
        /// </summary>
        /// <param name="userRoleServer"></param>
        public UserRoleController(IUserRoleServer userRoleServer)
        {
            _userRoleServer = userRoleServer;
        }
        /// <summary>
        /// 根据用户Id获取已分配的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UserRoleByUserId")]
        public async Task<MessageModel<List<Guid>>> GetRoleIdListByUserId([FromQuery] Guid userId)
        {
            var data = new MessageModel<List<Guid>>();
            try
            {
                var list = await _userRoleServer.GetRoleIdListByUserId(userId);
                data.success = true;
                data.msg = "数据获取成功";
                data.response = list;
                return data;
            }
            catch (Exception ex)
            {
                data.msg = "数据获取失败"+ex.Message;
                return data;
            }
        }
    }
}