$repGen = "E:\Manga Scan\Temp"
$dossGen = Get-ChildItem -Path $repGen
foreach ($manga in $dossGen)
{
	$sousDoss= Get-ChildItem -Path $manga.FullName
	
	if(![System.IO.Directory]::Exists("E:\Manga Scan\$($manga.name)")){
		New-Item "E:\Manga Scan\Manga\$($manga.name)" -itemType Directory
	}
	
	foreach($chapitre in $sousDoss){
		# echo "E:\Manga Scan\TestExtract\$($manga.name)\$([System.IO.Path]::GetFileNameWithoutExtension($chapitre))"
		Expand-Archive -LiteralPath "E:\Manga Scan\Temp\$($manga.name)\$($chapitre.name)" -DestinationPath "E:\Manga Scan\Manga\$($manga.name)\"	
	}
	Remove-item "E:\Manga Scan\Temp\$($manga.name)" -Recurse
}