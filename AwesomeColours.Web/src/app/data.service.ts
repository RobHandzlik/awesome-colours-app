import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { PersonDetail } from './models/person-detail';
import { Colour } from './models/colour';

export class DataService {
  public baseUrl: string;

  constructor(
    private readonly httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.baseUrl = baseUrl;
  } 

  getAllPersonDetails(): Observable<PersonDetail[]> {
    return this.httpClient
      .get<PersonDetail[]>('api/persondetails');
  }

  getPersonDetails(personId: number): Observable<PersonDetail> {
    return this.httpClient
      .get<PersonDetail>(`api/persondetails/${personId}`);
  }

  getAllColours(): Observable<Colour[]> {
    return this.httpClient
      .get<Colour[]>('api/colours');
  }

  postPersonDetails(request: PersonDetail): Observable<string> {
    return this.httpClient
      .post<string>('api/persondetails', request);
  }
}
