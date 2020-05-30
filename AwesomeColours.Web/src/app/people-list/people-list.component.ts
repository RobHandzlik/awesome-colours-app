import { Component, OnInit } from '@angular/core';
import { PersonDetail } from '../models/person-detail';
import { DataService } from '../data.service';

@Component({
  selector: 'app-people-list',
  templateUrl: './people-list.component.html'
})
export class PeopleListComponent implements OnInit {
  public personDetails: PersonDetail[];
  public errorMessage: string;

  constructor(private readonly dataService: DataService) {    
  }

  ngOnInit() {
    this.dataService.getAllPersonDetails()
      .subscribe(
        results => {
          this.personDetails = results;
        },
        error => this.errorMessage = 'Failed to get authorities'
      );
  }

}
