param(
  $title
)

if ($title -match 'change title to:\s*(.+)')
{
    Write-Host "Changing title to $($Matches[1])"
    az webapp config appsettings set -g github-action-rg -n github-action-demo --settings title=$($Matches[1])
}
else 
{
    Write-Host "Nothing to change."
}
