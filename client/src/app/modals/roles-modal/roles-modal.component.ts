import { MembersService } from './../../_services/members.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Component, Input, OnInit, EventEmitter } from '@angular/core';
import { User } from 'src/app/_models/user';
import { Member } from 'src/app/_models/Member';

@Component({
  selector: 'app-roles-modal',
  templateUrl: './roles-modal.component.html',
  styleUrls: ['./roles-modal.component.css']
})
export class RolesModalComponent implements OnInit {
  @Input() updateSelectedRoles = new EventEmitter();
  @Input() member: Member;
  user: User;
  roles: any[];

  constructor(public bsModalRef: BsModalRef, private toastr: ToastrService, private memberService: MembersService) { }

  ngOnInit(): void {
  }

  updateRoles(){
    this.updateSelectedRoles.emit(this.roles);
    this.bsModalRef.hide();
    //this.toastr.success('You have succesfully updated the role for this user');
  }

}
