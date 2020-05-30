import { Colour } from '../models/colour';

export class PersonDetail {
  constructor(
    public personId: number,
    public firstName: string,
    public lastName: string,
    public isAuthorised: boolean,
    public isValid: boolean,
    public isEnabled: boolean,
    public isPalindrome: boolean,

    public colours: Colour[]
  ) { }
}
