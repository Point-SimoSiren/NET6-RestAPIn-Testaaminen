
Luotu uusi testiprojekti hiiren oikealla solutionin päältä.
Uuden projektin tyyppi on MsTesting testiprojekti.

Lisätty hiiren oikealla uuden projektin päällä add, project reference ja rasti ruutuun niin että viittaa pääprojektiin.

Projektitiedostoon on lisätty:

	<ItemGroup>
		 <InternalsVisibleTo Include="$(AssemblyName).Tests" />
  	</ItemGroup>

   ***** Luultavasti pitää asentaa myös Microsoft.AspNetCore.Mvc.Testing niminen NuGet paketti *****
   ***** Ja laittaa se using lauseisiin *******

   Testikoodia on kirjoitettu oletuksena tulleeseen Kurssitestit.cs tiedostoon, jonka nimi oli aluksi TestClass1.cs tms. mutta nimi on muutettu.
   
