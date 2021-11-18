import { Iresult } from "../interfaces/iresult";
import { User } from "./user.model";
export class UserResult implements Iresult {
    success:boolean=false;
    userMessage:string="";
    result_set:User[]=[];
}
