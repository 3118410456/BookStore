import { Component, OnInit } from '@angular/core';
import { UserService } from '../service/user.service';
import { InputService } from '../service/input.service';
import Swal from 'sweetalert2';

declare var window: any;


@Component({
  selector: 'app-profile-user',
  templateUrl: './profile-user.component.html',
  styleUrls: ['./profile-user.component.scss']
})
export class ProfileUserComponent implements OnInit {
  submitted: any = false;
  profileForm: any = {
    "userID": 0,
    "username": "",
    "password": 0,
    "fullname": "",
    "birthday": "",
    "email": "",
    "role": "",
    "status": 0
  };

  changePassword :any = {
    oldPassword : '',
    newPassword : '',
    confirmPassword : '',
  }

  userJSON: any;
  formChangePassword :any;
  submitPass =  false;
  pass :any = false;

  constructor(private userService: UserService, private format: InputService) {
    userService.getAllUsers().subscribe(res => this.userJSON = res)
  }

  async ngOnInit() {
    const user = await this.getSessionUser()

    this.userService.getUserByID(user.userID).subscribe((data: any) => {
      this.profileForm = data
      this.profileForm.birthday = this.format.formatDate(data.birthday)
      console.log(this.profileForm);
    })

    this.creactformChangePassword()
  }

  

  async onSubmit() {
    this.submitted = true;
    if (this.isFormProfileValid()) {
      const result = await Swal.fire({
        title: 'Xác nhận cập nhật thông tin',
        // text: 'Bạn sẽ không thể hoàn tác lại sau khi xóa!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Có!',
        cancelButtonText: 'Không',
      });
    
      if (result.isConfirmed) {
        console.log(this.profileForm.fullname);
        
        this.userService.updateUser(this.profileForm).subscribe(res => console.log(res)
        )
        Swal.fire('CẬP NHẬT THÀNH CÔNG!', 'Đã lưu', 'success')   
      }
      
    }

  }

  async onChangePassword() {
    this.submitPass = true ;
    this.isCheckPassword()
    if(this.isFormPasswordValid()) {
      const result = await Swal.fire({
        title: 'Xác nhận đổi mật khẩu',
        // text: 'Bạn sẽ không thể hoàn tác lại sau khi xóa!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Có!',
        cancelButtonText: 'Không',
      });
    
      if (result.isConfirmed) {
        this.profileForm.password = this.changePassword.newPassword
        console.log(this.profileForm.fullname);
        
        this.userService.updateUser(this.profileForm).subscribe(res => console.log(res)
        )
        Swal.fire('ĐỔI MẬT KHẨU THÀNH CÔNG!', 'Đã lưu', 'success')   
      }
    }
  }


  getSessionUser() {
    let login: any = sessionStorage.getItem('login')
    return JSON.parse(login)
  }


  isValidEmail(email: string) {
    // Kiểm tra tính hợp lệ của địa chỉ email
    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    return emailPattern.test(email);
  }

  isFormProfileValid() {
    // Kiểm tra tính hợp lệ của biểu mẫu
    return (
      this.profileForm.fullname !== '' &&
      this.isValidEmail(this.profileForm.email) &&
      this.profileForm.birthday !== ''
    );
  }

  creactformChangePassword() {
    this.formChangePassword = new window.bootstrap.Modal(
      document.getElementById('exampleModal')
    );
  }

  openPopupChangePassword() {
    if (this.formChangePassword) {
      this.formChangePassword.show();
    } else {
      console.error('formChangePassword is not available.');
    }
  }
  closePopupChangePassword() {
    if (this.formChangePassword) {
      this.formChangePassword.hide();
    } else {
      console.error('formChangePassword is not available.');
    }
  }

  isFormPasswordValid() {
    // Kiểm tra tính hợp lệ của biểu mẫu
    return (     
      this.changePassword.oldPassword !== '' &&
      this.changePassword.newPassword !== '' &&
      this.isCheckPassword() &&
      this.changePassword.newPassword.length >= 6 &&
      this.changePassword.newPassword === this.changePassword.confirmPassword
    );
  }

  isCheckPassword() {
    console.log(this.changePassword.oldPassword + ' : ' + this.profileForm.password);
    let test :any;
    if(this.changePassword.oldPassword === this.profileForm.password) 
    {
      this.pass = true
      return true
    }
    else {
      this.pass = false
      return false
    }
    

  }

  


}
