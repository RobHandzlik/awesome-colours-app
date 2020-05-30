import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../data.service';
import { Colour } from '../models/colour';
import { PersonDetail } from '../models/person-detail';

@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styleUrls: ['./person-details.component.css']
})
export class PersonDetailsComponent implements OnInit {
  public personDetail: PersonDetail;
  colours: Colour[];
  selectedColourIds: number[];
  errorMessage: string;
  savedMessage: string;
  loading = true;

  constructor(
    private dataService: DataService,
    private route: ActivatedRoute,
    private router: Router) {     
  }

  ngOnInit() {
    const personId = +this.route.snapshot.paramMap.get('id');
    this.dataService.getPersonDetails(personId)
      .subscribe(
        results => {
          this.personDetail = results;
          this.dataService.getAllColours()
            .subscribe(
              results => {
                this.colours = results;
                this.loading = false;
                this.fillColours();
              },
              error => this.errorMessage = 'Failed to get colours'
            );
        },
        error => this.errorMessage = 'Failed to get person details'
    );
  }

  saveChanges(): void {
    this.dataService.postPersonDetails(this.personDetail)
      .subscribe(() => {
        this.savedMessage = "Details updated";

        setTimeout(() => {
          this.router.navigate(['/people']);
        }, 1500);
      },
        (er) => {
          this.errorMessage = 'Failed to save person details'
        });
  }

  fillColours(): void {
    this.colours.forEach((colour) => {
      let colourIncluded = this.personDetail.colours.find(obj => obj.colourId == colour.colourId);
      if (!colourIncluded) {
        this.personDetail.colours.push(colour);
      }
    });
  }

}
