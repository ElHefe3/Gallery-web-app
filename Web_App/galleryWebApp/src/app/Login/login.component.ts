import { ApplicationRef, Component, OnInit } from '@angular/core';
import { UserResult } from '../models/user-result.model';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  currentUser: User = new User();
  userResults: UserResult = new UserResult();
  load: string = 'no-show';
  disabled: string = '';
  constructor(private userService:UserService ) { }

  async ngOnInit(): Promise<void> {
    
  }

  async LogUserIn(): Promise<void> {
    this.userResults.result_set=[];
    var t = await this.userService
      .UserLogin()
      .then((data) => {
        if(data.success) {
          this.userResults = data;
        }else{
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert(error);
      });
  }

/*   async SubmitUser() {
    let result = new UserResult();
    await this.userService
      .UserLogin(this.currentUser)
      .then((data) => {
        result.success = data.success;
        result.userMessage = data.userMessage;
        if(result.success) {
          alert('Login Sucessful!')
        } else {
          alert(result.userMessage);
        }
        this.currentUser = new User();
      })
  } */
}
