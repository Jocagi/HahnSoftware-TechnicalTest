export interface User {
    email: string;
    password: string;
    firstName?: string;
    lastName?: string;
  }
  
  export class Register implements User {
    constructor(
      public email: string,
      public password: string,
      public firstName: string | undefined,
      public lastName: string | undefined
    ) {}
  }
  
  export class Login implements User {
    constructor(
      public email: string,
      public password: string
    ) {}
  }
  