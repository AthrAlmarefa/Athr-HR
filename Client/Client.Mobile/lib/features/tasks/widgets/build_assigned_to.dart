import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
class AssignAvatars extends StatelessWidget {
  final List<String> images;
  final int maxVisible;

  const AssignAvatars({
    super.key,
    required this.images,
    this.maxVisible = 2,
  });

  @override
  Widget build(BuildContext context) {
    int extra = images.length - maxVisible;
    int itemsToShow = images.length > maxVisible ? maxVisible : images.length;
    double overlap = 25.w;
    double stackWidth = (itemsToShow + (extra > 0 ? 1 : 0)) * overlap + 18.r;

    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          context.translate(LangKeys.assignTo),
          style: MyFonts.styleMedium500_16.copyWith(
            color: MyColors.navigationIconsInActiveColor,
          ),
        ),
        SizedBox(height: 16.h),
        SizedBox(
          width: stackWidth,
          height: 36.h,
          child: Stack(
            clipBehavior: Clip.none,
            children: [
              for (int i = 0; i < itemsToShow; i++)
                Positioned(
                  right: i * overlap,
                  child: CircleAvatar(
                    radius: 24.r,
                    backgroundImage: AssetImage(images[i]),
                  ),
                ),
              if (extra > 0)
                Positioned(
                  right: itemsToShow * overlap,
                  child: CircleAvatar(
                    radius: 24.r,
                    backgroundColor: MyColors.circleAvatarColor,
                    child: Text(
                      "$extra+",
                      style: MyFonts.styleMedium500_14.copyWith(
                        color: MyColors.white,
                      ),
                    ),
                  ),
                ),
            ],
          ),
        ),
      ],
    );
  }
}
