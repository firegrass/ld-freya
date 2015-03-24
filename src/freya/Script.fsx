r "../../packages/dotNetRDF/lib/net40/dotNetRDF.dll"
#r "../../packages/VDS.Common/lib/net40-client/VDS.Common.dll"
#r "../../packages/FSharpx.Core/lib/40/FSharpx.Core.dll"
#r "../../packages/FSharp.RDF/lib/net40/FSharp.RDF.dll"
#r "../../packages/Unquote/lib/net40/Unquote.dll"
#load "Model.fs"

open FSharp.RDF
open System.IO
open Swensen.Unquote
open Model
open System.Text.RegularExpressions
open resource

let prov = """
    @base <http://nice.org.uk/ns/compilation#>.

    @prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>.
    @prefix xsd: <http://www.w3.org/2001/XMLSchema#>.
    @prefix prov: <http://www.w3.org/ns/prov#>.
    @prefix owl: <http://www.w3.org/2002/07/owl#>.
    @prefix git2prov: <http://nice.org.uk/ns/prov#>.
    @prefix compilation: <http://nice.org.uk/ns/compilation#>.
    @prefix cnt: <http://www.w3.org/2011/content#>.
    @prefix tree: <http://nice.org.uk/git2prov/tree/master>.
    @prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#> .

    <http://nice.org.uk/ns/compilation#compilation/2015-02-23T12:12:47.2583040+00:00> a compilation:Compilation;
                                                                                    rdfs:label "Change this to a compilation message that is actualy useful to somebody";
                                                                                    prov:qualifiedAssociation [a prov:Association ;
                                                                                                                prov:agent <http://nice.org.uk/ns/prov#user/ryanroberts> ;
                                                                                                                prov:hadRole "initiator"];
                                                                                    prov:startedAtTime "2015-02-23T12:12:47.259270+00:00"^^xsd:dateTime;
                                                                                    prov:uses <http://nice.org.uk/ns/prov/commit/a71586c1dfe8a71c6cbf6c129f404c5642ff31bd/new.md>;
                                                                                    prov:wasAssociatedWith <http://nice.org.uk/ns/prov/user/ryanroberts>.

    <http://nice.org.uk/ns/prov/commit/a71586c1dfe8a71c6cbf6c129f404c5642ff31bd/new.md> compilation:path "new.md";
                                                                                        a prov:Entity;
                                                                                        cnt:chars "Some content "^^xsd:string;
                                                                                        prov:specializationOf <http://nice.org.uk/ns/prov/new.md>;
                                                                                        prov:wasAttributedTo <http://nice.org.uk/ns/prov/user/schacon@gmail.com>;
                                                                                        prov:wasGeneratedBy <http://nice.org.uk/ns/prov/commit/c47800c>.

"""

let g = Graph.from prov
let c = loadCompilation g
