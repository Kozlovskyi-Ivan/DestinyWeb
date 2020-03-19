export class Activities {
  constructor(
    public name?:string,
    public description?:string,
    public modifiers?:Modifier[]

  ){}
}
export class Modifier{
  constructor(
    public name?:string,
    public description?:string
  ){}
}
