﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using Microsoft.AspNetCore.Identity;
using DotVVMGL.Models;
using DotVVMGL.Services;

namespace DotVVMGL.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly StudentService studentService;

		public DefaultViewModel(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [Bind(Direction.ServerToClient)]
        public List<StudentListModel> Students { get; set; }

        public override async Task PreRender()
        {
            Students =  await studentService.GetAllStudentsAsync();
            await base.PreRender();
        }
    }
}