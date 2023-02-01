if(![System.IO.Directory]::Exists("E:\Drive\Mon Drive\Manga Scan")){
	New-Item -Path "E:\Drive\Mon Drive\Manga Scan" -ItemType Directory
}

$repGen = "E:\Manga Scan\Temp\"
$dossGen = Get-ChildItem -Path $repGen

foreach ($manga in $dossGen)
{
	$sousDoss= Get-ChildItem -Path $manga.FullName

	if(![System.IO.Directory]::Exists("E:\Drive\Mon Drive\Manga Scan\"+$manga.name)){
		New-Item "E:\Drive\Mon Drive\Manga Scan\$($manga.name)" -itemType Directory
	}
	
	foreach($chapitre in $sousDoss){
		if(![System.IO.File]::Exists("E:\Drive\Mon Drive\Manga Scan\$($manga.name)\$($chapitre.name).zip")){
			if($chapitre.name.contains("Chapitre")){
				#Write-Host "$($chapitre.FullName)" #Affichage du nom du répertoire et de son chemin complet
				Compress-Archive -Path "$($chapitre.FullName)" -DestinationPath "E:\Drive\Mon Drive\Manga Scan\$($manga.name)\$($chapitre.name).zip"		
			}
			
		}
	}
	Remove-item "E:\Manga Scan\Temp\$($manga.name)" -Recurse
}
