import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/data/implementation/offline_data_source_impl.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildTasksAttachmentsRow extends StatefulWidget {
   const BuildTasksAttachmentsRow({super.key});

   @override
   State<BuildTasksAttachmentsRow> createState() => _BuildTasksAttachmentsRowState();
 }

 class _BuildTasksAttachmentsRowState extends State<BuildTasksAttachmentsRow> {
   @override
   Widget build(BuildContext context) {
     return Column(
       children: [
         SizedBox(height: 16.h,),
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.attachments),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.navigationIconsInActiveColor,
             ),
           ),
         ),
         SizedBox(height: 20.h),
         Row(
           children: [
             Image.asset(Assets.imagesPdffile,
             width: 24.w,
             height: 24.h,
             fit: BoxFit.contain,),
             SizedBox(width: 12.w,),
             Text(context.translate(LangKeys.requirementsFile),style: MyFonts.semiBold600_18.copyWith(
               color: MyColors.black,
             ),),
             Spacer(),
             InkWell(
               onTap: ()async {
                 final dataSource = OfflineDataSourceImpl();
                 await dataSource.handleFileDownload(context);
               },
               child: Image.asset( Assets.imagesDownloadpdf,
               width: 24.w,
               height: 24.h,
               fit: BoxFit.contain,),
             ),
           ],
         ),
       ],
     );
   }
 }
