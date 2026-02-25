using MaiziWPF.Services.Application.Contracts;
using MaiziWPF.Services.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Prism.Ioc;
using System.Windows.Controls;
using MaiziWPF.Services.Domain.Shared;
using System.Linq;
using MaiziWPF.Common;

namespace MaiziWPF.Core
{
    public class TableAssist
    {
        public static readonly DependencyProperty TableProperty =
            DependencyProperty.RegisterAttached("Bind", typeof(String), typeof(TableAssist), new FrameworkPropertyMetadata(OnBindPropertyChanged));

        public static string GetBind(DependencyObject obj)
        {
            return (string)obj.GetValue(TableProperty);
        }

        public static void SetBind(DependencyObject obj, string value)
        {
            obj.SetValue(TableProperty, value);
        }
        private static void OnBindPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            List<Checked> datas = new();
            var container = ContainerLocator.Container;
            if (container != null)
            {
                if ((string)e.NewValue == "post" || (string)e.NewValue == "role")
                {

                    if ((string)e.NewValue == "post")
                    {
                        var service = container.Resolve<ISysPostService>();
                        datas = service.SelectPostList(new QueryPostInput() { PageNumber = 1, PageSize = 100 }).Select(a => new Checked { IsSelected = false, Name = a.PostName, Id = a.PostId }).ToList();
                    }
                    else if ((string)e.NewValue == "role")
                    {
                        var service = container.Resolve<ISysRoleService>();
                        datas = service.SelectRoleList(new QueryRoleInput() { PageNumber = 1, PageSize = 100 }).Select(a => new Checked { IsSelected = false, Name = a.RoleName, Id = a.RoleId }).ToList();
                    }
                    foreach (var item in datas)
                    {
                        item.PropertyChanged += (s, e) =>
                        {
                            if (e.PropertyName == nameof(Checked.IsSelected))
                            {
                                var selected = datas.Where(p => p.IsSelected).Select(p => p.Name).JoinAsString(",");
                                if (d is ComboBox cb)
                                {
                                    cb.Text = selected;
                                }
                            }
                        };
                    }
                }
                else if ((string)e.NewValue == "dept")
                {
                    var service = container.Resolve<ISysDeptService>();
                    var depts = service.SelectDeptList(new SysDept(), false).Select(a => new Checked { IsSelected = false, Name = a.DeptName, Id = a.Id, ParentId = a.ParentId,Childs=new System.Collections.ObjectModel.ObservableCollection<Checked>() }).ToList();
                    foreach (var item in depts)
                    {
                        item.PropertyChanged += (s, e) =>
                        {
                            if (e.PropertyName == nameof(Checked.IsSelected))
                            {

                            }
                        };
                    }
                    datas = depts.BuildTreeList(a => (int)a.Id, a => (int)a.ParentId, (p, c) => p.Childs.Add(c));
                }
            }
            if (d is ComboBox cb)
            {
                cb.ItemsSource = datas;
            }
        }
    }
}
