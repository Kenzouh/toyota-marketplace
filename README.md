# Setting up the MVC architecture:

1. Pick "MVC" from the dropdown menu in the top right corner of the project.
2. Create "Areas" folder.
3. Right Click Areas -> Press "Add" -> Press "Area..." -> Name it "Public".
4. Repeat step 3, but create "Admin" area instead of Public.
5. In Program.cs, replace "app.MapControllerRoute" block with this block (for default navigation):

'''
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { area = "Public", controller = "Home", action = "Homepage" });
'''

# Creating DB and seeding



# Installing Tailwind CSS


# Git-related stuff


## gitignore

Reference link: https://betterstack.com/community/questions/gitignore-vs-project-template/