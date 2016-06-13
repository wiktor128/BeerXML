﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Xml.Serialization;
using BeerXML.Models;
using System.IO;

namespace BeerXML.Tests
{
    public class UnitTest
    {
        [Fact]
        public void WaterSerializationTest()
        {
            #region arrange
            Water water = new Water
            {
                Name = "Aqua",
                Version = 2,
                Amount = 15,
                Calcium = 990,
                Bicarbonate = 8768,
                Sulfate = 6786,
                Chloride = 678678,
                Sodium = 2345,
                Magnesium = 345,
                Ph = 4,
                Notes = "Better than tap water."
                //WaterRecipes
            };
            string expected = @"<?xml version=""1.0"" encoding=""utf-16""?>
<Water xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <NAME>Aqua</NAME>
  <VERSION>2</VERSION>
  <AMOUNT>15</AMOUNT>
  <CALCIUM>990</CALCIUM>
  <BICARBONATE>8768</BICARBONATE>
  <SULFATE>6786</SULFATE>
  <CHLORIDE>678678</CHLORIDE>
  <SODIUM>2345</SODIUM>
  <MAGNESIUM>345</MAGNESIUM>
  <PH>4</PH>
  <NOTES>Better than tap water.</NOTES>
</Water>";
            #endregion

            #region act
            XmlSerializer serializer = new XmlSerializer(typeof(Water));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, water);
            string result = writer.ToString();
            #endregion

            #region assert
            Assert.Equal(expected, result);
            #endregion
        }

        [Fact]
        public void RecipeSerializationTest()
        {
            #region arrange
            Recipe recipe = new Recipe
            {
                //RecipeID = ,
                Name = "Cheap Beer",
                Version = 1,
                Type = "Grain",
                Brewer = "Me",
                AsstBrewer = "None",
                BatchSize = 111,
                BoilSize = 11,
                BoilTime = 11,
                Efficiency = 1,
                // WaterRecipes = ,
                Notes = "Good for breakfast",
                TasteNotes = "It taste like mushrooms",
                TasteRating = 10,
                OG = 12,
                FG = 2,
                FermentationStages = 2,
                PrimaryAges = 23,
                PrimaryTemp = 32,
                SecondaryAge = 653,
                SecondaryTemp = 346,
                TertiaryAge = 346,
                TertiaryTemp = 346,
                Age = 23,
                AgeTemp = 33,
                Date = DateTime.Today.ToString(),
                Carbonation = 90,
                ForcedCarbonation = false,
                PrimingSugarName = "Diamant",
                CarbonationTemp = 44,
                PrimingSugarEquiv = 3,
                KegPrimingFactor = 3
            };
            string expected = @"<?xml version=""1.0"" encoding=""utf-16""?>
<Recipe xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <NAME>Cheap Beer</NAME>
  <VERSION>1</VERSION>
  <TYPE>Grain</TYPE>
  <BREWER>Me</BREWER>
  <ASST_BREWER>None</ASST_BREWER>
  <BATCH_SIZE>111</BATCH_SIZE>
  <BOIL_SIZE>11</BOIL_SIZE>
  <BOIL_TIME>11</BOIL_TIME>
  <EFFICIENCY>1</EFFICIENCY>
  <NOTES>Good for breakfast</NOTES>
  <TEST_NOTES>It taste like mushrooms</TEST_NOTES>
  <TASTE_RATING>10</TASTE_RATING>
  <OG>12</OG>
  <FG>2</FG>
  <FERMENTATION_STAGES>2</FERMENTATION_STAGES>
  <PRIMARY_AGES>23</PRIMARY_AGES>
  <PRIMARY_TEMP>32</PRIMARY_TEMP>
  <SECONDARY_AGE>653</SECONDARY_AGE>
  <SECONDARY_TEMP>346</SECONDARY_TEMP>
  <TERTIARY_AGE>346</TERTIARY_AGE>
  <TERTIARY_TEMP>346</TERTIARY_TEMP>
  <AGE>23</AGE>
  <AGE_TEMP>33</AGE_TEMP>
  <DATE>07.06.2016 00:00:00</DATE>
  <CARBONATION>90</CARBONATION>
  <FORCED_CARBONATION>false</FORCED_CARBONATION>
  <PRIMING_SUGAR_NAME>Diamant</PRIMING_SUGAR_NAME>
  <CARBONATION_TEMP>44</CARBONATION_TEMP>
  <PRIMING_SUGAR_EQUIV>3</PRIMING_SUGAR_EQUIV>
  <KEG_PRIMING_FACTOR>3</KEG_PRIMING_FACTOR>
</Recipe>";
            #endregion

            #region act
            XmlSerializer serializer = new XmlSerializer(typeof(Recipe));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, recipe);
            string result = writer.ToString();
            #endregion

            #region assert
            Assert.Equal(expected, result);
            #endregion
        }

        [Fact]
        public void RecipeDeserializationTest()
        {
            #region arrange
            string recipeXml = @"<?xml version=""1.0"" encoding=""utf-16""?>
<Recipe xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Name>Cheap Beer</Name>
  <Version>1</Version>
  <Type>Grain</Type>
  <Brewer>Me</Brewer>
  <AsstBrewer>None</AsstBrewer>
  <BatchSize>111</BatchSize>
  <BoilSize>11</BoilSize>
  <BoilTime>11</BoilTime>
  <Efficiency>1</Efficiency>
  <Notes>Good for breakfast</Notes>
  <TasteNotes>It taste like mushrooms</TasteNotes>
  <TasteRating>10</TasteRating>
  <OG>12</OG>
  <FG>2</FG>
  <FermentationStages>2</FermentationStages>
  <PrimaryAges>23</PrimaryAges>
  <PrimaryTemp>32</PrimaryTemp>
  <SecondaryAge>653</SecondaryAge>
  <SecondaryTemp>346</SecondaryTemp>
  <TertiaryAge>346</TertiaryAge>
  <TertiaryTemp>346</TertiaryTemp>
  <Age>23</Age>
  <AgeTemp>33</AgeTemp>
  <Date>06.06.2016 00:00:00</Date>
  <Carbonation>90</Carbonation>
  <ForcedCarbonation>false</ForcedCarbonation>
  <PrimingSugarName>Diamant</PrimingSugarName>
  <CarbonationTemp>44</CarbonationTemp>
  <PrimingSugarEquiv>3</PrimingSugarEquiv>
  <KegPrimingFactor>3</KegPrimingFactor>
</Recipe>";
            string trueRecipeXml = @"<Recipe>
<NAME>Burton Ale</NAME>
<VERSION>1</VERSION>
<TYPE>All Grain</TYPE>
<BREWER>Brad Smith</BREWER>
<ASST_BREWER/>
<BATCH_SIZE>18.92716800</BATCH_SIZE>
<BOIL_SIZE>20.81988500</BOIL_SIZE>
<BOIL_TIME>60</BOIL_TIME>
<EFFICIENCY>72.0</EFFICIENCY>
<HOPS>
<HOP>
<NAME>Goldings, East Kent</NAME>
<VERSION>1</VERSION>
<ORIGIN>United Kingdom</ORIGIN>
<ALPHA>5.50</ALPHA>
<AMOUNT>0.0283500</AMOUNT>
<USE>Boil</USE>
<TIME>60.000</TIME>
<NOTES>
Used For: General purpose hops for bittering/finishing all British Ales Aroma: Floral, aromatic, earthy, slightly sweet spicy flavor Substitutes: Fuggles, BC Goldings Examples: Bass Pale Ale, Fullers ESB, Samual Smith's Pale Ale
</NOTES>
<TYPE>Aroma</TYPE>
<FORM>Pellet</FORM>
<BETA>3.50</BETA>
<HSI>35.0</HSI>
<DISPLAY_AMOUNT>1.00 oz</DISPLAY_AMOUNT>
<INVENTORY>1.00 oz</INVENTORY>
<DISPLAY_TIME>60 min</DISPLAY_TIME>
</HOP>
<HOP>
<NAME>Northern Brewer</NAME>
<VERSION>1</VERSION>
<ORIGIN>Germany</ORIGIN>
<ALPHA>7.50</ALPHA>
<AMOUNT>0.0141750</AMOUNT>
<USE>Boil</USE>
<TIME>60.000</TIME>
<NOTES>
Also called Hallertauer Northern Brewers Use for: Bittering and finishing both ales and lagers of all kinds Aroma: Fine, dry, clean bittering hop. Unique flavor. Substitute: Hallertauer Mittelfrueh, Hallertauer Examples: Anchor Steam, Old Peculiar,
</NOTES>
<TYPE>Both</TYPE>
<FORM>Pellet</FORM>
<BETA>4.00</BETA>
<HSI>35.0</HSI>
<DISPLAY_AMOUNT>0.50 oz</DISPLAY_AMOUNT>
<INVENTORY>0.50 oz</INVENTORY>
<DISPLAY_TIME>60 min</DISPLAY_TIME>
</HOP>
<HOP>
<NAME>Fuggles</NAME>
<VERSION>1</VERSION>
<ORIGIN>United Kingdom</ORIGIN>
<ALPHA>5.00</ALPHA>
<AMOUNT>0.0141750</AMOUNT>
<USE>Boil</USE>
<TIME>2.000</TIME>
<NOTES>
Used For: General purpose bittering/aroma for English Ales, Dark Lagers Aroma: Mild, soft, grassy, floral aroma Substitute: East Kent Goldings, Williamette Examples: Samuel Smith's Pale Ale, Old Peculiar, Thomas Hardy's Ale
</NOTES>
<TYPE>Aroma</TYPE>
<FORM>Pellet</FORM>
<BETA>2.00</BETA>
<HSI>35.0</HSI>
<DISPLAY_AMOUNT>0.50 oz</DISPLAY_AMOUNT>
<INVENTORY>0.50 oz</INVENTORY>
<DISPLAY_TIME>2 min</DISPLAY_TIME>
</HOP>
<HOP>
<NAME>Fuggles</NAME>
<VERSION>1</VERSION>
<ORIGIN>United Kingdom</ORIGIN>
<ALPHA>4.50</ALPHA>
<AMOUNT>0.0212620</AMOUNT>
<USE>Dry Hop</USE>
<TIME>4320.00</TIME>
<NOTES>
Used For: General purpose bittering/aroma for English Ales, Dark Lagers Aroma: Mild, soft, grassy, floral aroma Substitute: East Kent Goldings, Williamette Examples: Samuel Smith's Pale Ale, Old Peculiar, Thomas Hardy's Ale
</NOTES>
<TYPE>Aroma</TYPE>
<FORM>Pellet</FORM>
<BETA>2.00</BETA>
<HSI>35.0</HSI>
<DISPLAY_AMOUNT>0.75 oz</DISPLAY_AMOUNT>
<INVENTORY>0.75 oz</INVENTORY>
<DISPLAY_TIME>3 days</DISPLAY_TIME>
</HOP>
</HOPS>
<FERMENTABLES>
<FERMENTABLE>
<NAME>Pale Malt (2 Row) UK</NAME>
<VERSION>1</VERSION>
<TYPE>Grain</TYPE>
<AMOUNT>3.628736</AMOUNT>
<YIELD>78.0</YIELD>
<COLOR>2.5</COLOR>
<ADD_AFTER_BOIL>FALSE</ADD_AFTER_BOIL>
<ORIGIN>United Kingdom</ORIGIN>
<SUPPLIER/>
<NOTES>
Base malt for all English beer styles Lower diastatic power than American 2 Row Pale Malt
</NOTES>
<COARSE_FINE_DIFF>1.5</COARSE_FINE_DIFF>
<MOISTURE>4.0</MOISTURE>
<DIASTATIC_POWER>45.0</DIASTATIC_POWER>
<PROTEIN>10.1</PROTEIN>
<MAX_IN_BATCH>100.0</MAX_IN_BATCH>
<RECOMMEND_MASH>FALSE</RECOMMEND_MASH>
<IBU_GAL_PER_LB>0.000</IBU_GAL_PER_LB>
<DISPLAY_AMOUNT>8.00 lb</DISPLAY_AMOUNT>
<INVENTORY>8.00 lb</INVENTORY>
<POTENTIAL>1.036</POTENTIAL>
<DISPLAY_COLOR>2.5 SRM</DISPLAY_COLOR>
</FERMENTABLE>
<FERMENTABLE>
<NAME>Caramel/Crystal Malt - 20L</NAME>
<VERSION>1</VERSION>
<TYPE>Grain</TYPE>
<AMOUNT>0.453592</AMOUNT>
<YIELD>75.0</YIELD>
<COLOR>20.0</COLOR>
<ADD_AFTER_BOIL>FALSE</ADD_AFTER_BOIL>
<ORIGIN>US</ORIGIN>
<SUPPLIER/>
<NOTES>
Adds body, color and improves head retention. Also called ""Crystal"" malt.
</NOTES>
<COARSE_FINE_DIFF>1.5</COARSE_FINE_DIFF>
<MOISTURE>4.0</MOISTURE>
<DIASTATIC_POWER>0.0</DIASTATIC_POWER>
<PROTEIN>13.2</PROTEIN>
<MAX_IN_BATCH>20.0</MAX_IN_BATCH>
<RECOMMEND_MASH>FALSE</RECOMMEND_MASH>
<IBU_GAL_PER_LB>0.000</IBU_GAL_PER_LB>
<DISPLAY_AMOUNT>1.00 lb</DISPLAY_AMOUNT>
<INVENTORY>1.00 lb</INVENTORY>
<POTENTIAL>1.035</POTENTIAL>
<DISPLAY_COLOR>20.0 SRM</DISPLAY_COLOR>
</FERMENTABLE>
<FERMENTABLE>
<NAME>Brown Sugar, Light</NAME>
<VERSION>1</VERSION>
<TYPE>Sugar</TYPE>
<AMOUNT>0.453592</AMOUNT>
<YIELD>100.0</YIELD>
<COLOR>8.0</COLOR>
<ADD_AFTER_BOIL>FALSE</ADD_AFTER_BOIL>
<ORIGIN>US</ORIGIN>
<SUPPLIER/>
<NOTES>
Imparts a rich sweet flavor. Used in Scottish ales, holiday ales and some old ales.
</NOTES>
<COARSE_FINE_DIFF>0</COARSE_FINE_DIFF>
<MOISTURE>0</MOISTURE>
<DIASTATIC_POWER>0</DIASTATIC_POWER>
<PROTEIN>0</PROTEIN>
<MAX_IN_BATCH>10.0</MAX_IN_BATCH>
<RECOMMEND_MASH>FALSE</RECOMMEND_MASH>
<IBU_GAL_PER_LB>0.000</IBU_GAL_PER_LB>
<DISPLAY_AMOUNT>1.00 lb</DISPLAY_AMOUNT>
<INVENTORY>1.00 lb</INVENTORY>
<POTENTIAL>1.046</POTENTIAL>
<DISPLAY_COLOR>8.0 SRM</DISPLAY_COLOR>
</FERMENTABLE>
</FERMENTABLES>
<MISCS>
<MISC>
<NAME>Irish Moss</NAME>
<VERSION>1</VERSION>
<TYPE>Fining</TYPE>
<USE>Boil</USE>
<AMOUNT>0.001232</AMOUNT>
<TIME>10.000</TIME>
<AMOUNT_IS_WEIGHT>FALSE</AMOUNT_IS_WEIGHT>
<USE_FOR>Clarity</USE_FOR>
<NOTES>
Fining agent that aids in the post-boil protein break. Reduces protein chill haze and improves beer clarity.
</NOTES>
<DISPLAY_AMOUNT>0.25 tsp</DISPLAY_AMOUNT>
<INVENTORY>0.00 tsp</INVENTORY>
<DISPLAY_TIME>10.0 min</DISPLAY_TIME>
<BATCH_SIZE>5.00 gal</BATCH_SIZE>
</MISC>
<MISC>
<NAME>Polyclar</NAME>
<VERSION>1</VERSION>
<TYPE>Fining</TYPE>
<USE>Secondary</USE>
<AMOUNT>0.007393</AMOUNT>
<TIME>1440.000</TIME>
<AMOUNT_IS_WEIGHT>FALSE</AMOUNT_IS_WEIGHT>
<USE_FOR>Chill Haze</USE_FOR>
<NOTES>
Plastic powder that reduces chill haze by removing tannins and proteins. Add to secondary after yeast has settled. Amounts vary by manufacturer -- check instructions before adding. Do not boil.
</NOTES>
<DISPLAY_AMOUNT>0.25 oz</DISPLAY_AMOUNT>
<INVENTORY>0.00 oz</INVENTORY>
<DISPLAY_TIME>1.0 days</DISPLAY_TIME>
<BATCH_SIZE>5.00 gal</BATCH_SIZE>
</MISC>
</MISCS>
<YEASTS>
<YEAST>
<NAME>Burton Ale</NAME>
<VERSION>1</VERSION>
<TYPE>Ale</TYPE>
<FORM>Liquid</FORM>
<AMOUNT>0.0350130</AMOUNT>
<AMOUNT_IS_WEIGHT>FALSE</AMOUNT_IS_WEIGHT>
<LABORATORY>White Labs</LABORATORY>
<PRODUCT_ID>WLP023</PRODUCT_ID>
<MIN_TEMPERATURE>20.0000</MIN_TEMPERATURE>
<MAX_TEMPERATURE>22.7778</MAX_TEMPERATURE>
<FLOCCULATION>Medium</FLOCCULATION>
<ATTENUATION>72.0</ATTENUATION>
<NOTES>
Burton-on-trent yeast produces a complex character. Flavors include apple, pear, and clover honey.
</NOTES>
<BEST_FOR>
All English styles including Pale Ale, IPA, Porter, Stout and Bitters.
</BEST_FOR>
<MAX_REUSE>5</MAX_REUSE>
<TIMES_CULTURED>0</TIMES_CULTURED>
<ADD_TO_SECONDARY>FALSE</ADD_TO_SECONDARY>
<DISPLAY_AMOUNT>35 ml</DISPLAY_AMOUNT>
<DISP_MIN_TEMP>68.0 F</DISP_MIN_TEMP>
<DISP_MAX_TEMP>73.0 F</DISP_MAX_TEMP>
<INVENTORY>0 Pkgs</INVENTORY>
<CULTURE_DATE>7/6/2003</CULTURE_DATE>
</YEAST>
</YEASTS>
<WATERS>
<WATER>
<NAME>Burton On Trent, UK</NAME>
<VERSION>1</VERSION>
<AMOUNT>18.927168</AMOUNT>
<CALCIUM>295.0</CALCIUM>
<BICARBONATE>300.0</BICARBONATE>
<SULFATE>725.0</SULFATE>
<CHLORIDE>25.0</CHLORIDE>
<SODIUM>55.0</SODIUM>
<MAGNESIUM>45.0</MAGNESIUM>
<PH>8.0</PH>
<NOTES>
Distinctive pale ales strongly hopped. Very hard water accentuates the hops flavor. Example: Bass Ale
</NOTES>
<DISPLAY_AMOUNT>5.00 gal</DISPLAY_AMOUNT>
</WATER>
</WATERS>
<STYLE>
<NAME>English Pale Ale</NAME>
<VERSION>1</VERSION>
<CATEGORY>Bitter English Pale Ale</CATEGORY>
<CATEGORY_NUMBER>1</CATEGORY_NUMBER>
<STYLE_LETTER>A</STYLE_LETTER>
<STYLE_GUIDE>BJCP 1999</STYLE_GUIDE>
<TYPE>Ale</TYPE>
<OG_MIN>1.04300000</OG_MIN>
<OG_MAX>1.06000000</OG_MAX>
<FG_MIN>1.01000000</FG_MIN>
<FG_MAX>1.02000000</FG_MAX>
<IBU_MIN>20.0</IBU_MIN>
<IBU_MAX>40.0</IBU_MAX>
<COLOR_MIN>6.00000000</COLOR_MIN>
<COLOR_MAX>12.00000000</COLOR_MAX>
<CARB_MIN>1.5</CARB_MIN>
<CARB_MAX>2.4</CARB_MAX>
<ABV_MAX>5.5</ABV_MAX>
<ABV_MIN>4.5</ABV_MIN>
<NOTES>
Famous style from Burton-on-Trent. Stronger body than ordinary bitter, but slightly less bitter. A balanced, easy drinking beer that is malty and strong but not overbearing.
</NOTES>
<PROFILE>
Medium to full body, with medium to high bitterness and hop aroma. Dry with a defined hop flavor. Golden to copper color. Crystal malt evident. Low carbonation for kegs, medium for bottled version.
</PROFILE>
<INGREDIENTS>
English malt. Crystal malt. English hops. Water with high Calcium Sulfate (gypsum) profile enhances bitterness perception (i.e. famous Burton-on-Trent Water)
</INGREDIENTS>
<EXAMPLES>Bass Pale Ale, Whitbread Pale Ale, Royal Oak</EXAMPLES>
<DISPLAY_OG_MIN>1.043 SG</DISPLAY_OG_MIN>
<DISPLAY_OG_MAX>1.060 SG</DISPLAY_OG_MAX>
<DISPLAY_FG_MIN>1.010 SG</DISPLAY_FG_MIN>
<DISPLAY_FG_MAX>1.020 SG</DISPLAY_FG_MAX>
<DISPLAY_COLOR_MIN>6.0 SRM</DISPLAY_COLOR_MIN>
<DISPLAY_COLOR_MAX>12.0 SRM</DISPLAY_COLOR_MAX>
<OG_RANGE>1.043-1.060 SG</OG_RANGE>
<FG_RANGE>1.010-1.020 SG</FG_RANGE>
<IBU_RANGE>20.0-40.0 IBU</IBU_RANGE>
<CARB_RANGE>1.5-2.4 vols</CARB_RANGE>
<COLOR_RANGE>6.0-12.0 SRM</COLOR_RANGE>
<ABV_RANGE>4.5-5.5 %</ABV_RANGE>
</STYLE>
<EQUIPMENT>
<NAME>Brew Pot (6+gal) and Igloo/Gott Cooler (5 Gal)</NAME>
<VERSION>1</VERSION>
<BOIL_SIZE>22.70566900</BOIL_SIZE>
<BATCH_SIZE>18.927168</BATCH_SIZE>
<TUN_VOLUME>18.92716800</TUN_VOLUME>
<TUN_WEIGHT>1.814368</TUN_WEIGHT>
<TUN_SPECIFIC_HEAT>0.300</TUN_SPECIFIC_HEAT>
<TOP_UP_WATER>0.00000000</TOP_UP_WATER>
<TRUB_CHILLER_LOSS>0.94635800</TRUB_CHILLER_LOSS>
<EVAP_RATE>9.0</EVAP_RATE>
<BOIL_TIME>60.0</BOIL_TIME>
<CALC_BOIL_VOLUME>FALSE</CALC_BOIL_VOLUME>
<LAUTER_DEADSPACE>0.94635800</LAUTER_DEADSPACE>
<TOP_UP_KETTLE>0.00000000</TOP_UP_KETTLE>
<HOP_UTILIZATION>100.0</HOP_UTILIZATION>
<NOTES>
Popular all grain setup. 5 Gallon Gott or Igloo cooler as mash tun with false bottom, and 7-9 gallon brewpot capable of boiling at least 6 gallons of wort. Primarily used for single infusion mashes.
</NOTES>
<DISPLAY_BOIL_SIZE>6.00 gal</DISPLAY_BOIL_SIZE>
<DISPLAY_BATCH_SIZE>5.00 gal</DISPLAY_BATCH_SIZE>
<DISPLAY_TUN_VOLUME>5.00 gal</DISPLAY_TUN_VOLUME>
<DISPLAY_TUN_WEIGHT>4.00 lb</DISPLAY_TUN_WEIGHT>
<DISPLAY_TOP_UP_WATER>0.00 gal</DISPLAY_TOP_UP_WATER>
<DISPLAY_TRUB_CHILLER_LOSS>0.25 gal</DISPLAY_TRUB_CHILLER_LOSS>
<DISPLAY_LAUTER_DEADSPACE>0.25 gal</DISPLAY_LAUTER_DEADSPACE>
<DISPLAY_TOP_UP_KETTLE>0.00 gal</DISPLAY_TOP_UP_KETTLE>
</EQUIPMENT>
<MASH>
<NAME>Single Infusion, Full Body</NAME>
<VERSION>1</VERSION>
<GRAIN_TEMP>22.22222200</GRAIN_TEMP>
<TUN_TEMP>22.22222200</TUN_TEMP>
<SPARGE_TEMP>75.55555600</SPARGE_TEMP>
<PH>5.4</PH>
<TUN_WEIGHT>1.81436800</TUN_WEIGHT>
<TUN_SPECIFIC_HEAT>0.30000000</TUN_SPECIFIC_HEAT>
<EQUIP_ADJUST>FALSE</EQUIP_ADJUST>
<NOTES/>
<DISPLAY_GRAIN_TEMP>72.0 F</DISPLAY_GRAIN_TEMP>
<DISPLAY_TUN_TEMP>72.0</DISPLAY_TUN_TEMP>
<DISPLAY_SPARGE_TEMP>168.0 F</DISPLAY_SPARGE_TEMP>
<DISPLAY_TUN_WEIGHT>4.00 lb</DISPLAY_TUN_WEIGHT>
<MASH_STEPS>
<MASH_STEP>
<NAME>Mash In</NAME>
<VERSION>1</VERSION>
<TYPE>Infusion</TYPE>
<INFUSE_AMOUNT>10.646532</INFUSE_AMOUNT>
<STEP_TIME>45</STEP_TIME>
<STEP_TEMP>70.00000000</STEP_TEMP>
<RAMP_TIME>2</RAMP_TIME>
<END_TEMP>70.00000000</END_TEMP>
<DESCRIPTION>Add 11.25 qt of water at 170.5 F</DESCRIPTION>
<WATER_GRAIN_RATIO>1.25</WATER_GRAIN_RATIO>
<DECOCTION_AMT>0.00 qt</DECOCTION_AMT>
<INFUSE_TEMP>170.5 F</INFUSE_TEMP>
<DISPLAY_STEP_TEMP>DISPLAY_STEP_TEMP</DISPLAY_STEP_TEMP>
<DISPLAY_INFUSE_AMT>11.25 qt</DISPLAY_INFUSE_AMT>
</MASH_STEP>
<MASH_STEP>
<NAME>Mash Out</NAME>
<VERSION>1</VERSION>
<TYPE>Infusion</TYPE>
<INFUSE_AMOUNT>6.813780</INFUSE_AMOUNT>
<STEP_TIME>10</STEP_TIME>
<STEP_TEMP>75.55555600</STEP_TEMP>
<RAMP_TIME>2</RAMP_TIME>
<END_TEMP>75.55555600</END_TEMP>
<DESCRIPTION>Add 7.20 qt of water at 185.9 F</DESCRIPTION>
<WATER_GRAIN_RATIO>2.05</WATER_GRAIN_RATIO>
<DECOCTION_AMT>0.00 qt</DECOCTION_AMT>
<INFUSE_TEMP>185.9 F</INFUSE_TEMP>
<DISPLAY_STEP_TEMP>DISPLAY_STEP_TEMP</DISPLAY_STEP_TEMP>
<DISPLAY_INFUSE_AMT>7.20 qt</DISPLAY_INFUSE_AMT>
</MASH_STEP>
</MASH_STEPS>
</MASH>
<NOTES/>
<TASTE_NOTES>
A smooth tasting pale ale -- full in body and a great long lasting head. Another great beer to stock -- favorite with guests. Make's a great black and tan when combined with light bodied Irish stout.
</TASTE_NOTES>
<TASTE_RATING>38.0</TASTE_RATING>
<OG>1.05400000</OG>
<FG>1.01500000</FG>
<CARBONATION>2.4</CARBONATION>
<FERMENTATION_STAGES>2</FERMENTATION_STAGES>
<PRIMARY_AGE>4</PRIMARY_AGE>
<PRIMARY_TEMP>20.000</PRIMARY_TEMP>
<SECONDARY_AGE>7</SECONDARY_AGE>
<SECONDARY_TEMP>20.000</SECONDARY_TEMP>
<TERTIARY_AGE>0</TERTIARY_AGE>
<AGE>14.0</AGE>
<AGE_TEMP>11.111</AGE_TEMP>
<CARBONATION_USED>12 PSI</CARBONATION_USED>
<DATE>4/6/2003</DATE>
<EST_OG>1.056 SG</EST_OG>
<EST_FG>1.015 SG</EST_FG>
<EST_COLOR>7.0 SRM</EST_COLOR>
<IBU>32.4 IBU</IBU>
<IBU_METHOD>Tinseth</IBU_METHOD>
<EST_ABV>5.3 %</EST_ABV>
<ABV>5.1 %</ABV>
<ACTUAL_EFFICIENCY>69.7 %</ACTUAL_EFFICIENCY>
<CALORIES>242 cal/pint</CALORIES>
<DISPLAY_BATCH_SIZE>5.00 gal</DISPLAY_BATCH_SIZE>
<DISPLAY_BOIL_SIZE>5.50 gal</DISPLAY_BOIL_SIZE>
<DISPLAY_OG>1.054 SG</DISPLAY_OG>
<DISPLAY_FG>1.015 SG</DISPLAY_FG>
<DISPLAY_PRIMARY_TEMP>68.0 F</DISPLAY_PRIMARY_TEMP>
<DISPLAY_SECONDARY_TEMP>68.0 F</DISPLAY_SECONDARY_TEMP>
<DISPLAY_TERTIARY_TEMP>68.0 F</DISPLAY_TERTIARY_TEMP>
<DISPLAY_AGE_TEMP>52.0 F</DISPLAY_AGE_TEMP>
</Recipe>";
            #endregion

            #region act
            XmlSerializer deserializer = new XmlSerializer(typeof(Recipe));
            StringReader reader = new StringReader(trueRecipeXml);
            Recipe recipe = (Recipe)deserializer.Deserialize(reader);
            reader.Close();

            #endregion

            #region assert
            #endregion
        }
    }
}