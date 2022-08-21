#include <iostream>
#include <string>
using namespace std;

bool CheckRow(int grid[6][6], int rand_num, int row, int col)
{
    int temp_row = row;
    bool all_is_well = true;

    while (temp_row > 0)
    {
        temp_row--;
        if (grid[temp_row][col] == rand_num)
        {
            all_is_well = false;
        }
    }
    return all_is_well;
}
bool CheckCol(int grid[6][6], int rand_num, int row, int col)
{
    int temp_col = col;
    bool all_is_well = true;
    while (temp_col > 0)
    {
        temp_col--;
        if (grid[row][temp_col] == rand_num)
        {
            all_is_well = false;
        }
    }
    return all_is_well;
}
 string DisplayPlayerGrid(int player_grid[6][6]) {

    string string_grid[6][6];

    for (int r = 0; r < 6; r++) {
        for (int s = 0; s < 6; s++) {
            string_grid[r][s] = to_string(player_grid[r][s]);
        }
    }

    string points[10];
    
    for (int i = 0; i < 10; i++) {
        bool found = false;
        int row = rand() % 5 + 1;
        int col = rand() % 5 + 1;
        string coordinates = to_string(row)+ ":" + to_string(col);
        for (int j = 0; j < 10; j++) {
            if (points[j] == coordinates) {
                found = true;
            }
        }
        if (!found) {
            points[i] = coordinates;
            string_grid[row][col] = "";
        }

       

    }
    for (int p = 0; p < 6; p++) {
        for (int m = 0; m < 6; m++) {
            if (m < 6) {
                cout << string_grid[p][m] << " | ";
            }
        }
        cout << endl
            << "-----------------------" << endl;
    }
    cout << endl;

    return string_grid[5][5];
}
int main()
{
    const int size = 6;
    int rand_num, i, grid[size][size];
    int player_grid[size][size];
    int j = 0;
    string level, exit;
    int six_index = 0;
    bool all_is_well = false;
    int six[6] = { 1,2,3,4,5,6 };
    int t_six[6] = { 1,2,3,4,5,6 };
    //initialize random seed
    srand(time(NULL));

    //generates a random grid
    for (i = 0; i < size; i++)
    {
        if (i == 1) {
            int p = i;
        }
        //for (j = 0; j < size; j++)
        j = 0;
        while (j < 6)
        {

            all_is_well = false;
           
            while (all_is_well == false)
            {
                rand_num = rand() % size + 1;
                all_is_well = CheckRow(grid, rand_num, i, j);
                if (all_is_well == true)
                    all_is_well = CheckCol(grid, rand_num, i, j);

                    /*Check to see if all random numbers have been exhausted for a specific (row, col)*/
                    for (int g = 0; g < 6; g++) {
                        if (six[g] == rand_num) {
                            six_index++;
                            six[g] = 0;
                        }
                    }
                    /*If exhausted for (row, col) and all is not well reset column to zero and tester "six"*/
                    if (six_index == 6 && !all_is_well) {
                        j = 0;
                        six_index = 0;
                        for (int l = 0; l < 6; l++) {
                            six[l] = l+1;
                        }
                        break;
                    } else if (six_index == 6 && all_is_well) {

                        /*if exhausted and all is well reset (row, column) tester "six"*/
                        six_index = 0;
                        for (int l = 0; l < 6; l++) {
                            six[l] = l + 1;
                        }
                    }
                
            }
            
            if (all_is_well) {
                grid[i][j] = rand_num;
                j++;
                for (int l = 0; l < 6; l++) {
                    six[l] = l + 1;
                }
            }
        }
        
    }
    DisplayPlayerGrid(grid);
    /*for (int p = 0; p < 6; p++) {
        for (int m = 0; m < 6; m++) {
            if (m < 6) {
                cout << grid[p][m] << " | ";
            }
        } 
        cout << endl
            << "-----------------------" << endl;
    }
    cout << endl;*/

    //introduction
    cout << "WELCOME TO SIX LOVE!\n";
    cout << "Select your skill level:\n 1. Rookie\n 2. Tuff Gong\n 3. Hard Seed\n>> ";
    cin >> level;

    if (level == "Rookie")
    {
        cout << "\nGreat choice!" << endl;
        cout << "Before we begin, note the following:" << endl;
        cout << "1. You have one hint." << endl;
        cout << "2. Points will be deducted when you use your hint" << endl;
        cout << "3. You will lose the game if you try to use another hint" << endl;
        cout << "4. You can exit the game at any time by entering 'quit'\n"
             << endl;

        //cout << grid[size][size] << " | ";
    }

    return 0;
}