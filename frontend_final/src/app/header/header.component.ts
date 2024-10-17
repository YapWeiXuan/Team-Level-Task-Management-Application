import { Component } from "@angular/core";

@Component(
    {
        selector: 'app-header',
        // template: '<h1>Hello World</h1>'
        standalone:true,
        templateUrl: './header.component.html',
        styleUrls:['./header.component.css']
        // styles:['h1 {color: red}']

    }
)
// @Component(
//   {
//       selector: 'app-header',
//       // template: '<h1>Hello World</h1>'
//       standalone:false,
//       templateUrl: './header.component.html',
//       styleUrls:['./header.component.css']
//       // styles:['h1 {color: red}']

//   }
// )

export class HeaderComponent{}
