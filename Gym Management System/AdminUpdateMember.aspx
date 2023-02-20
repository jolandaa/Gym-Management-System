﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminUpdateMember.aspx.cs" Inherits="Gym_Management_System.AdminUpdateMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <!--
=========================================================
 Material Dashboard - v2.1.1
=========================================================

 Product Page: https://www.creative-tim.com/product/material-dashboard
 Copyright 2019 Creative Tim (https://www.creative-tim.com)
 Licensed under MIT (https://github.com/creativetimofficial/material-dashboard/blob/master/LICENSE.md)

 Coded by Creative Tim

=========================================================

 The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. -->

  <meta charset="utf-8" />
  <link rel="apple-touch-icon" sizes="76x76" href="Dashboard/assets/img/apple-icon.png">
  <link rel="icon" type="image/png" href="Dashboard/assets/img/favicon.png">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
  <title>
    Material Dashboard by Creative Tim
  </title>
  <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0, shrink-to-fit=no' name='viewport' />
  <!--     Fonts and icons     -->
  <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">
  <!-- CSS Files -->
  <link href="Dashboard/assets/css/material-dashboard.css?v=2.1.1" rel="stylesheet" />
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="Dashboard/assets/demo/demo.css" rel="stylesheet" />

  <div class="wrapper ">
    
    <div class="main-panel">
      <!-- Navbar -->
      <nav class="navbar navbar-expand-lg navbar-transparent navbar-absolute fixed-top ">
        <div class="container-fluid">
          <div class="navbar-wrapper">
            <a class="navbar-brand" href="#">User Profile</a>
          </div>
          <button class="navbar-toggler" type="button" data-toggle="collapse" aria-controls="navigation-index" aria-expanded="false" aria-label="Toggle navigation">
            <span class="sr-only">Toggle navigation</span>
            <span class="navbar-toggler-icon icon-bar"></span>
            <span class="navbar-toggler-icon icon-bar"></span>
            <span class="navbar-toggler-icon icon-bar"></span>
          </button>
         
        </div>
      </nav>
      <!-- End Navbar -->
      <div class="content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-8">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h4 class="card-title">Update Member</h4>
                  <p class="card-category">Change Your Member Profile</p>
                </div>
                <div class="card-body">
                
                    <div class="row">
                      <div class="col-md-8">
                        <div class="form-group">
                          <label class="bmd-label-floating">Name<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator></label>
                          <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                        
                        </div>
                        <div class="form-group">
                          <label class="bmd-label-floating">Contact No<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtContact" ForeColor="Red"></asp:RequiredFieldValidator></label>
                          <asp:TextBox ID="txtContact" runat="server" class="form-control" TextMode="Phone"></asp:TextBox>
                       
                        </div>
                         <div class="form-group">
                          <label class="bmd-label-floating">Email address<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator></label>
                          <asp:TextBox ID="txtEmail" runat="server" class="form-control" TextMode="Email"></asp:TextBox>
                       
                        </div>
                          <br>
                        <div class="form-group">
                          <label class="bmd-label-floating">Gender<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="rbtGender" ForeColor="Red"></asp:RequiredFieldValidator></label>
                          <asp:RadioButtonList ID="rbtGender" runat="server" RepeatDirection="Horizontal">
                              <asp:ListItem>Male</asp:ListItem>
                              <asp:ListItem>Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="form-group">
                          <label class="bmd-label-floating">Height</label>
                          <asp:TextBox ID="txtHeight" runat="server" class="form-control"></asp:TextBox>
                       
                        </div>
                      
                        <div class="form-group">
                          <label class="bmd-label-floating">Weight</label>
                          <asp:TextBox ID="txtWeight" runat="server" class="form-control"></asp:TextBox>
                       
                        </div>
                                                
                        <div class="form-group">
                          <label class="bmd-label-floating">BMI</label>
                          <asp:TextBox ID="txtBMI" runat="server" class="form-control"></asp:TextBox>
                       
                        </div>
                        <div class="form-group">
                          <label class="bmd-label-floating">Date Of Birth</label>
                          <asp:TextBox ID="txtDob" runat="server" class="form-control"></asp:TextBox>
                       
                        </div>

                        <div class="form-group">
                          <label class="bmd-label-floating">City</label>
                          <asp:TextBox ID="txtCity" runat="server" class="form-control"></asp:TextBox>
                        
                        </div>

                        <div class="form-group">
                          <label class="bmd-label-floating">State</label>
                          <asp:TextBox ID="txtState" runat="server" class="form-control"></asp:TextBox>
                        
                        </div>

                        <div class="form-group">
                          <label class="bmd-label-floating">Address</label>
                          <asp:TextBox ID="txtAddress" runat="server" class="form-control" Rows="4" TextMode="MultiLine"></asp:TextBox>
                       
                        </div>

                          <div class="form-group">
                          <label class="bmd-label-floating">Date Of Join</label>
                          <asp:TextBox ID="txtDOJ" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                        
                        </div>

                          <div class="form-group">
                          <label class="bmd-label-floating">Expire Training Date</label>
                          <asp:TextBox ID="txtExpireDate" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                        
                        </div>

                        <div class="form-group">
                          <label class="bmd-label-floating">From (Enter Time Example: 9:30 PM)<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ControlToValidate="txtFrom" ForeColor="Red"></asp:RequiredFieldValidator></label>
                          <asp:TextBox ID="txtFrom" runat="server" class="form-control" TextMode="DateTime"></asp:TextBox>
                        
                        </div>

                         <div class="form-group">
                          <label class="bmd-label-floating">To ((Enter Time Example: 11:00 PM))<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="*" ControlToValidate="txtTo" ForeColor="Red"></asp:RequiredFieldValidator></label>
                          <asp:TextBox ID="txtTo" runat="server" class="form-control" TextMode="DateTime"></asp:TextBox>
                        
                        </div>
                        
                        <div class="form-group">
                          <label class="bmd-label-floating">Number Of Training Month<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="txtMonth" ForeColor="Red"></asp:RequiredFieldValidator></label>
                          <asp:TextBox ID="txtMonth" runat="server" class="form-control" OnTextChanged="txtMonth_TextChanged" TextMode="Number"></asp:TextBox>
                        
                        </div>

                        <div class="form-group">
                          <label class="bmd-label-floating">One Month Fee<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ControlToValidate="txtOneMonthFee" ForeColor="Red"></asp:RequiredFieldValidator></label>
                          <asp:TextBox ID="txtOneMonthFee" runat="server" class="form-control" OnTextChanged="txtOneMonthFee_TextChanged" TextMode="Number"></asp:TextBox>
                        
                        </div>

                        <div class="form-group">
                          <label class="bmd-label-floating">Total Fee<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ControlToValidate="txtTotalFee" ForeColor="Red"></asp:RequiredFieldValidator></label>
                          <asp:TextBox ID="txtTotalFee" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
                        
                        </div>

                        <div class="form-group">
                          <label class="bmd-label-floating">Received Fee<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ControlToValidate="txtReceivedFee" ForeColor="Red"></asp:RequiredFieldValidator></label>
                          <asp:TextBox ID="txtReceivedFee" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
                       
                        </div>


                        <div class="form-group">
                          <label class="bmd-label-floating">Password</label><asp:TextBox ID="txtPass" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                       
                        </div>
                      </div>
                     
                    </div>
                    
                    <asp:Button ID="btnAdd" runat="server" Text="Update" class="btn btn-primary pull-left" OnClick="btnAdd_Click" />
                    
                    <div class="clearfix"></div>
                
                </div>
              </div>
            </div>
       
          </div>
        </div>
      </div>
      
    </div>
  </div>

  <!--   Core JS Files   -->
  <script src="Dashboard/assets/js/core/jquery.min.js"></script>
  <script src="Dashboard/assets/js/core/popper.min.js"></script>
  <script src="Dashboard/assets/js/core/bootstrap-material-design.min.js"></script>
  <script src="Dashboard/assets/js/plugins/perfect-scrollbar.jquery.min.js"></script>
  <!-- Plugin for the momentJs  -->
  <script src="Dashboard/assets/js/plugins/moment.min.js"></script>
  <!--  Plugin for Sweet Alert -->
  <script src="Dashboard/assets/js/plugins/sweetalert2.js"></script>
  <!-- Forms Validations Plugin -->
  <script src="Dashboard/assets/js/plugins/jquery.validate.min.js"></script>
  <!-- Plugin for the Wizard, full documentation here: https://github.com/VinceG/twitter-bootstrap-wizard -->
  <script src="Dashboard/assets/js/plugins/jquery.bootstrap-wizard.js"></script>
  <!--	Plugin for Select, full documentation here: http://silviomoreto.github.io/bootstrap-select -->
  <script src="Dashboard/assets/js/plugins/bootstrap-selectpicker.js"></script>
  <!--  Plugin for the DateTimePicker, full documentation here: https://eonasdan.github.io/bootstrap-datetimepicker/ -->
  <script src="Dashboard/assets/js/plugins/bootstrap-datetimepicker.min.js"></script>
  <!--  DataTables.net Plugin, full documentation here: https://datatables.net/  -->
  <script src="Dashboard/assets/js/plugins/jquery.dataTables.min.js"></script>
  <!--	Plugin for Tags, full documentation here: https://github.com/bootstrap-tagsinput/bootstrap-tagsinputs  -->
  <script src="Dashboard/assets/js/plugins/bootstrap-tagsinput.js"></script>
  <!-- Plugin for Fileupload, full documentation here: http://www.jasny.net/bootstrap/javascript/#fileinput -->
  <script src="Dashboard/assets/js/plugins/jasny-bootstrap.min.js"></script>
  <!--  Full Calendar Plugin, full documentation here: https://github.com/fullcalendar/fullcalendar    -->
  <script src="Dashboard/assets/js/plugins/fullcalendar.min.js"></script>
  <!-- Vector Map plugin, full documentation here: http://jvectormap.com/documentation/ -->
  <script src="Dashboard/assets/js/plugins/jquery-jvectormap.js"></script>
  <!--  Plugin for the Sliders, full documentation here: http://refreshless.com/nouislider/ -->
  <script src="Dashboard/assets/js/plugins/nouislider.min.js"></script>
  <!-- Include a polyfill for ES6 Promises (optional) for IE11, UC Browser and Android browser support SweetAlert -->
  <script src="https://cdnjs.cloudflare.com/ajax/libs/core-js/2.4.1/core.js"></script>
  <!-- Library for adding dinamically elements -->
  <script src="Dashboard/assets/js/plugins/arrive.min.js"></script>
  <!--  Google Maps Plugin    -->
  <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE"></script>
  <!-- Chartist JS -->
  <script src="Dashboard/assets/js/plugins/chartist.min.js"></script>
  <!--  Notifications Plugin    -->
  <script src="Dashboard/assets/js/plugins/bootstrap-notify.js"></script>
  <!-- Control Center for Material Dashboard: parallax effects, scripts for the example pages etc -->
  <script src="Dashboard/assets/js/material-dashboard.js?v=2.1.1" type="text/javascript"></script>
  <!-- Material Dashboard DEMO methods, don't include it in your project! -->
  <script src="Dashboard/assets/demo/demo.js"></script>
  <script>
      $(document).ready(function () {
          $().ready(function () {
              $sidebar = $('.sidebar');

              $sidebar_img_container = $sidebar.find('.sidebar-background');

              $full_page = $('.full-page');

              $sidebar_responsive = $('body > .navbar-collapse');

              window_width = $(window).width();

              fixed_plugin_open = $('.sidebar .sidebar-wrapper .nav li.active a p').html();

              if (window_width > 767 && fixed_plugin_open == 'Dashboard') {
                  if ($('.fixed-plugin .dropdown').hasClass('show-dropdown')) {
                      $('.fixed-plugin .dropdown').addClass('open');
                  }

              }

              $('.fixed-plugin a').click(function (event) {
                  // Alex if we click on switch, stop propagation of the event, so the dropdown will not be hide, otherwise we set the  section active
                  if ($(this).hasClass('switch-trigger')) {
                      if (event.stopPropagation) {
                          event.stopPropagation();
                      } else if (window.event) {
                          window.event.cancelBubble = true;
                      }
                  }
              });

              $('.fixed-plugin .active-color span').click(function () {
                  $full_page_background = $('.full-page-background');

                  $(this).siblings().removeClass('active');
                  $(this).addClass('active');

                  var new_color = $(this).data('color');

                  if ($sidebar.length != 0) {
                      $sidebar.attr('data-color', new_color);
                  }

                  if ($full_page.length != 0) {
                      $full_page.attr('filter-color', new_color);
                  }

                  if ($sidebar_responsive.length != 0) {
                      $sidebar_responsive.attr('data-color', new_color);
                  }
              });

              $('.fixed-plugin .background-color .badge').click(function () {
                  $(this).siblings().removeClass('active');
                  $(this).addClass('active');

                  var new_color = $(this).data('background-color');

                  if ($sidebar.length != 0) {
                      $sidebar.attr('data-background-color', new_color);
                  }
              });

              $('.fixed-plugin .img-holder').click(function () {
                  $full_page_background = $('.full-page-background');

                  $(this).parent('li').siblings().removeClass('active');
                  $(this).parent('li').addClass('active');


                  var new_image = $(this).find("img").attr('src');

                  if ($sidebar_img_container.length != 0 && $('.switch-sidebar-image input:checked').length != 0) {
                      $sidebar_img_container.fadeOut('fast', function () {
                          $sidebar_img_container.css('background-image', 'url("' + new_image + '")');
                          $sidebar_img_container.fadeIn('fast');
                      });
                  }

                  if ($full_page_background.length != 0 && $('.switch-sidebar-image input:checked').length != 0) {
                      var new_image_full_page = $('.fixed-plugin li.active .img-holder').find('img').data('src');

                      $full_page_background.fadeOut('fast', function () {
                          $full_page_background.css('background-image', 'url("' + new_image_full_page + '")');
                          $full_page_background.fadeIn('fast');
                      });
                  }

                  if ($('.switch-sidebar-image input:checked').length == 0) {
                      var new_image = $('.fixed-plugin li.active .img-holder').find("img").attr('src');
                      var new_image_full_page = $('.fixed-plugin li.active .img-holder').find('img').data('src');

                      $sidebar_img_container.css('background-image', 'url("' + new_image + '")');
                      $full_page_background.css('background-image', 'url("' + new_image_full_page + '")');
                  }

                  if ($sidebar_responsive.length != 0) {
                      $sidebar_responsive.css('background-image', 'url("' + new_image + '")');
                  }
              });

              $('.switch-sidebar-image input').change(function () {
                  $full_page_background = $('.full-page-background');

                  $input = $(this);

                  if ($input.is(':checked')) {
                      if ($sidebar_img_container.length != 0) {
                          $sidebar_img_container.fadeIn('fast');
                          $sidebar.attr('data-image', '#');
                      }

                      if ($full_page_background.length != 0) {
                          $full_page_background.fadeIn('fast');
                          $full_page.attr('data-image', '#');
                      }

                      background_image = true;
                  } else {
                      if ($sidebar_img_container.length != 0) {
                          $sidebar.removeAttr('data-image');
                          $sidebar_img_container.fadeOut('fast');
                      }

                      if ($full_page_background.length != 0) {
                          $full_page.removeAttr('data-image', '#');
                          $full_page_background.fadeOut('fast');
                      }

                      background_image = false;
                  }
              });

              $('.switch-sidebar-mini input').change(function () {
                  $body = $('body');

                  $input = $(this);

                  if (md.misc.sidebar_mini_active == true) {
                      $('body').removeClass('sidebar-mini');
                      md.misc.sidebar_mini_active = false;

                      $('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar();

                  } else {

                      $('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar('destroy');

                      setTimeout(function () {
                          $('body').addClass('sidebar-mini');

                          md.misc.sidebar_mini_active = true;
                      }, 300);
                  }

                  // we simulate the window Resize so the charts will get updated in realtime.
                  var simulateWindowResize = setInterval(function () {
                      window.dispatchEvent(new Event('resize'));
                  }, 180);

                  // we stop the simulation of Window Resize after the animations are completed
                  setTimeout(function () {
                      clearInterval(simulateWindowResize);
                  }, 1000);

              });
          });
      });
  </script>



</asp:Content>
