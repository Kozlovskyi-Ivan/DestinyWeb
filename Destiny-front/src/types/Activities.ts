export class Activities {
  constructor(
    public name?:string,
    public description?:string,
    public modifiers?:Modifier[],
    public icon?:string

  ){}
}
export class Modifier{
  constructor(
    public name?:string,
    public description?:string,
    public icon?:string
  ){}
}
