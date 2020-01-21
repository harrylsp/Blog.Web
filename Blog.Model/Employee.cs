using ServiceStack.DataAnnotations;
using System;

namespace Blog.Model
{
    public class Employee
    {
        /// <summary>
        /// 标识Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 用户表Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 所属上级
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public int Role { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [IgnoreOnUpdate]
        public int Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [IgnoreOnInsert]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [IgnoreOnInsert]
        public int Reviser { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [IgnoreOnInsert]
        [IgnoreOnUpdate]
        public DateTime? ReviseTime { get; set; }

        /// <summary>
        /// 业务主管
        /// </summary>
        [Ignore]
        public string SalesExecutiveName { get; set; }
    }
}
