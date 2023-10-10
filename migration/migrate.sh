# Assuming you start from the first commit (oldest)
git rev-list --reverse HEAD | while read commit; do
    # Get the original author information
    original_author_name="$(git --no-pager show -s --format='%an' $commit)"
    original_author_email="$(git --no-pager show -s --format='%ae' $commit)"

    # Check out the specific commit
    git checkout $commit

    # Check if the commit already exists in the target repository
    if git log --oneline --format="%H" | grep -q "$commit"; then
        echo "Commit $commit already exists in the target repository. Skipping."
    else
        # Display information about the current commit
        echo "Migrating commit: $commit"
        echo "Original Author: $original_author_name <$original_author_email>"

        # Create a new commit in the target repository with amended author info
        git commit --author="$original_author_name <$original_author_email>" --allow-empty -C $commit

        # Push the new commit to the target repository
        git push git@rendu-git.etna-alternance.net:module-9251/activity-50408/group-996424.git dev

        # Display a message indicating the commit has been migrated
        echo "Commit migrated: $commit"
    fi
done
