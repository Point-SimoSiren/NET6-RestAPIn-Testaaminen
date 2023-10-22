
Luotu uusi testiprojekti hiiren oikealla solutionin päältä.
Uuden projektin tyyppi on MsTesting testiprojekti.

Lisätty hiiren oikealla uuden projektin päällä add, project reference ja rasti ruutuun niin että viittaa pääprojektiin.

Projektitiedostoon on lisätty:

	<ItemGroup>
		 <InternalsVisibleTo Include="$(AssemblyName).Tests" />
  </ItemGroup>
