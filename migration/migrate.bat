@echo off
setlocal enabledelayedexpansion

:: Assuming you start from the first commit (oldest)
for /f %%c in ('git rev-list --reverse HEAD') do (
    :: Get the original author information
    for /f "delims=" %%a in ('git log -1 --format^="%an^|%ae" %%c') do (
        for /f "tokens=1,2 delims=^|" %%n in ("%%a") do (
            set "original_author_name=%%n"
            set "original_author_email=%%o"
        )
    )

    :: Check if the commit already exists in the target repository
    git log --oneline --format^="%H" | findstr "!original_author_name!" >nul
    if errorlevel 1 (
        echo Migrating commit: %%c
        echo Original Author: !original_author_name! ^<!original_author_email!^>

        :: Check out the specific commit
        git checkout %%c

        :: Create a new commit in the target repository with amended author info
        git commit --author^="!original_author_name! ^<!original_author_email!^>" --allow-empty -C %%c

        :: Push the new commit to the target repository
        git push git@rendu-git.etna-alternance.net:module-9251/activity-50408/group-996424.git migration

        echo Commit migrated: %%c
    ) else (
        echo Commit %%c already exists in the target repository. Skipping.
    )
)

endlocal
